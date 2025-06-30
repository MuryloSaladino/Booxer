import { Component, effect, inject, signal } from "@angular/core";
import { CalendarEvent, CalendarModule } from "angular-calendar";
import { ReservationService } from "../../core/services/reservation.service";
import { AuthService } from "../../core/services/auth.service";
import { Reservation } from "../../core/types/reservation.entity";
import { DialogModule } from "primeng/dialog";
import { CommonModule } from "@angular/common";
import { ReservationDetailsComponent } from "../../shared/reservation-details/reservation-details.component";
import { ButtonModule } from "primeng/button";
import dayjs from "dayjs";
import { ConfirmationService } from "primeng/api";
import { ConfirmDialogModule } from "primeng/confirmdialog";
import { RouterModule } from "@angular/router";

@Component({
    selector: "calendar",
    templateUrl: "./calendar.component.html",
    styleUrl: "./calendar.component.css",
    standalone: true,
    imports: [
        CalendarModule,
        DialogModule,
        CommonModule,
        ReservationDetailsComponent,
        ButtonModule,
        ConfirmDialogModule,
        RouterModule,
    ],
})
export class CalendarComponent {

    readonly date = signal<Date>(new Date());
    readonly auth = inject(AuthService);
    readonly confirmation = inject(ConfirmationService);
    readonly reservationService = inject(ReservationService);
    readonly events = signal<CalendarEvent<Reservation>[]>([]);

    readonly selectedEvent = signal<CalendarEvent<Reservation> | null>(null);
    openDetails = false;

    constructor() {
        effect(async () => {
            const reservations = await this.reservationService.getAll({
                reservedById: this.auth.user()?.id,
                start: dayjs(this.date()).startOf('week').toDate(),
                end: dayjs(this.date()).endOf('week').toDate(),
            });
            this.events.set(reservations.map(r => ({
                start: new Date(r.startsAt),
                end: new Date(r.endsAt),
                title: `${r.resource.name} (${new Date(r.startsAt).getHours()}h - ${new Date(r.endsAt).getHours()}h)`,
                meta: r,
            })));
        });
    }

    onEventClick(event: CalendarEvent) {
        this.selectedEvent.set(event);
        this.openDetails = true;
    }

    cancelCurrentReservation() {
        this.confirmation.confirm({
            header: 'Are you sure you wish to cancel this reservation?',
            acceptLabel: "Cancel Reservation",
            rejectLabel: "Keep It",
            accept: async () => await this.reservationService.delete(this.selectedEvent()!.meta!.id, {
                errorFeedback: true,
                successFeedback: {
                    message: "Reservation confirmed!",
                    details: "Reservation cancelled"
                }}
            ),
        });
    }
}
