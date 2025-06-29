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
    ],
    providers: [ConfirmationService]
})
export class ReservationComponent implements OnInit {

    readonly route = inject(ActivatedRoute);
    readonly router = inject(Router);
    readonly auth = inject(AuthService);

    readonly resourceService = inject(ResourceService);
    readonly resource = signal<Resource | null>(null);

    readonly reservationService = inject(ReservationService);
    readonly reservations = signal<Reservation[]>([]);

    readonly reservationMessages = computed<Message[]>(() => this.reservations().map(r => ({
        severity: "warn",
        detail: `Reservation for ${r.reservedBy}
                ${dayjs(r.startsAt).format("DD/MM/YYYY HH:mm")} - ${dayjs(r.endsAt).format("DD/MM/YYYY HH:mm")}`,
        closable: false,
    })));
    readonly confirmation = inject(ConfirmationService);

    range: [Date, Date] = this.getRangeStarterValue();

    async ngOnInit() {
        const resourceId = this.route.snapshot.paramMap.get("resourceId");
        const response = await this.resourceService.getById(resourceId!);
        this.resource.set(response);
    }

    async fetchReservationsInRange(range: Date[]) {
        if(!range[0] || !range[1]) return;
        const response = await this.reservationService.getAll({
            start: range[0],
            end: range[1],
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
                    startsAt: this.range[0],
                    endsAt: this.range[1],
                    resourceId: this.resource()!.id,
                }, { errorFeedback: true, successFeedback: {
                    message: "Reservation confirmed!",
                    details: `${this.resource()?.name} reserved for ${dayjs(this.range[0]).format("DD/MM/YYYY [at] HH:mm")}`
                }})
                this.router.navigate([AppRoutes.DASHBOARD]);
            },
        });
    }

    private getRangeStarterValue(): [Date, Date] {
        const start = new Date();
        start.setMinutes(0);
        start.setDate(start.getDate() + 1);

        const end = new Date(start);
        end.setDate(start.getDate() + 1);

        return [start, end];
    }
}
