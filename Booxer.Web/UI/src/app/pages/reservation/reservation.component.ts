import { Component, inject, OnInit, signal } from "@angular/core";
import { ActivatedRoute, Router, RouterModule } from "@angular/router";
import { ResourceService } from "../../core/services/resource.service";
import { CalendarModule as NGCalendarModule } from 'primeng/calendar';
import { FormsModule } from "@angular/forms";
import { Resource } from "../../core/types/resource.entity";
import { ReservationService } from "../../core/services/reservation.service";
import { Reservation } from "../../core/types/reservation.entity";
import { CommonModule } from "@angular/common";
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { ConfirmationService, Message } from "primeng/api";
import { AppRoutes } from "../../core/constants/app-routes";
import { MessagesModule } from 'primeng/messages';
import { AuthService } from "../../core/services/auth.service";
import { DividerModule } from "primeng/divider";
import { ReservationRulesComponent } from "../../shared/reservation-rules/reservation-rules.component";
import { ReservationDetailsComponent } from "../../shared/reservation-details/reservation-details.component";
import { isDateInHourRange, mergeDateAndTime } from "../../core/utils/date";
import { ReservationTipComponent } from "../../shared/reservation-tip/reservation-tip.component";
import dayjs from "dayjs";
import { CalendarEvent, CalendarModule } from "angular-calendar";

@Component({
    selector: 'reservation',
    templateUrl: './reservation.component.html',
    styleUrl: './reservation.component.css',
    standalone: true,
    imports: [
        NGCalendarModule,
        CalendarModule,
        FormsModule,
        CommonModule,
        ConfirmDialogModule,
        RouterModule,
        MessagesModule,
        DividerModule,
        ReservationRulesComponent,
        ReservationDetailsComponent,
        ReservationTipComponent,
    ],
})
export class ReservationComponent implements OnInit {

    readonly route = inject(ActivatedRoute);
    readonly router = inject(Router);
    readonly auth = inject(AuthService);

    readonly resourceService = inject(ResourceService);
    readonly resource = signal<Resource | null>(null);

    readonly reservationService = inject(ReservationService);
    readonly reservations = signal<Reservation[]>([]);
    readonly reservationHistory = signal<CalendarEvent<Reservation>[]>([]);

    readonly confirmation = inject(ConfirmationService);
    readonly invalid = signal(false);

    reservationDay = dayjs().add(1, "day").toDate();
    startsAt = dayjs().add(1, "day").set("hour", 8).startOf("hour").toDate();
    endsAt = dayjs().add(1, "day").set("hour", 12).startOf("hour").toDate();

    async ngOnInit() {
        const resourceId = this.route.snapshot.paramMap.get("resourceId");
        const response = await this.resourceService.getById(resourceId!);
        this.resource.set(response);
        await this.validate();
        await this.updateHistory();
    }

    async validate() {
        const duration = this.endsAt.getHours() - this.startsAt.getHours();

        const response = await this.reservationService.getAll({
            start: mergeDateAndTime(this.reservationDay, this.startsAt),
            end: mergeDateAndTime(this.reservationDay, this.endsAt),
            resourceId: this.resource()!.id,
        });
        this.reservations.set(response);

        this.invalid.set(
            dayjs(this.reservationDay).isBefore(dayjs())
            || !isDateInHourRange(this.startsAt, 8, 18)
            || !isDateInHourRange(this.endsAt, 8, 18)
            || (duration > 8 || duration < 0)
            || response.length > 0
        )

        await this.updateHistory();
    }

    async reserve() {
        this.confirmation.confirm({
            header: 'Review Reservation Details',
            acceptLabel: "Confirm",
            rejectLabel: "Cancel",
            accept: async () => {
                await this.reservationService.create({
                    startsAt: mergeDateAndTime(this.reservationDay, this.startsAt),
                    endsAt: mergeDateAndTime(this.reservationDay, this.endsAt),
                    resourceId: this.resource()!.id,
                }, { errorFeedback: true, successFeedback: {
                    message: "Reservation confirmed!",
                    details: `${this.resource()?.name} reserved for ${dayjs(this.reservationDay).format("DD/MM/YYYY [at] HH:mm")}`
                }})
                this.router.navigate([AppRoutes.DASHBOARD]);
            },
        });
    }

    async updateHistory() {
        if(this.resource()) {
            const history = await this.reservationService.getAll({
                start: dayjs(this.reservationDay).startOf("week").toDate(),
                end: dayjs(this.reservationDay).endOf("week").toDate(),
                resourceId: this.resource()!.id
            });
            this.reservationHistory.set(history.map(r => ({
                title: `${r.reservedBy} (${new Date(r.startsAt).getHours()}h - ${new Date(r.endsAt).getHours()}h)`,
                start: new Date(r.startsAt),
                end: new Date(r.endsAt),
            })))
        }
    }
}
