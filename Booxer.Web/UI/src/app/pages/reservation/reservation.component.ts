import { Component, computed, inject, OnInit, signal } from "@angular/core";
import { ActivatedRoute, Router, RouterModule } from "@angular/router";
import { ResourceService } from "../../core/services/resource.service";
import { CalendarModule } from 'primeng/calendar';
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

@Component({
    selector: 'reservation',
    templateUrl: './reservation.component.html',
    styleUrl: './reservation.component.css',
    standalone: true,
    imports: [
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

    readonly confirmation = inject(ConfirmationService);

    reservationDay = dayjs().add(1, "day").toDate();
    startsAt = dayjs().add(1, "day").set("hour", 8).startOf("hour").toDate();
    endsAt = dayjs().add(1, "day").set("hour", 12).startOf("hour").toDate();

    async ngOnInit() {
        const resourceId = this.route.snapshot.paramMap.get("resourceId");
        const response = await this.resourceService.getById(resourceId!);
        this.resource.set(response);
        await this.validate();
    }

    async validate() {
        if(dayjs(this.reservationDay).isBefore(dayjs())) {
            this.reservationDay = new Date();
        }

        if(!isDateInHourRange(this.startsAt, 8, 18))
            this.startsAt = dayjs(this.startsAt).set("hour", 8).toDate();
        if(!isDateInHourRange(this.endsAt, 8, 18))
            this.endsAt = dayjs(this.endsAt).set("hour", 18).toDate();

        const duration = this.endsAt.getHours() - this.startsAt.getHours();
        if(duration > 8 || duration < 0) {
            this.startsAt = dayjs(this.startsAt).set("hour", 8).toDate();
            this.endsAt = dayjs(this.endsAt).set("hour", 12).toDate();
        }

        const response = await this.reservationService.getAll({
            start: mergeDateAndTime(this.reservationDay, this.startsAt),
            end: mergeDateAndTime(this.reservationDay, this.endsAt),
            resourceId: this.resource()!.id,
        });
        this.reservations.set(response);
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
}
