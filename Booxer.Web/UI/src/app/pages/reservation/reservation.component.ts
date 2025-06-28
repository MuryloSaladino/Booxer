import { Component, computed, effect, inject, OnInit, signal } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { ResourceService } from "../../core/services/resource.service";
import { CalendarModule } from 'primeng/calendar';
import { FormBuilder, FormGroup, FormsModule } from "@angular/forms";
import { Resource } from "../../core/types/resource.entity";
import { ReservationService } from "../../core/services/reservation.service";
import { Reservation } from "../../core/types/reservation.entity";
import { CommonModule } from "@angular/common";
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { ConfirmationService } from "primeng/api";

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
    ],
    providers: [ConfirmationService]
})
export class ReservationComponent implements OnInit {

    readonly route = inject(ActivatedRoute);
    readonly resourceService = inject(ResourceService);
    readonly reservationService = inject(ReservationService);
    readonly confirmation = inject(ConfirmationService);
    readonly resource = signal<Resource | null>(null);
    readonly reservations = signal<Reservation[]>([]);

    range: [Date, Date] = this.getCurrentWeekRange();

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
            acceptLabel: "Confirm Reservation",
            rejectLabel: "Cancel",
            acceptButtonStyleClass: "accept",
            rejectButtonStyleClass: "reject",
            accept: async () => {
                await this.reservationService.create({
                    startsAt: this.range[0],
                    endsAt: this.range[1],
                    resourceId: this.resource()!.id,
                })
            },
        });
    }

    private getCurrentWeekRange(): [Date, Date] {
        const now = new Date();
        const dayOfWeek = now.getDay();

        const start = new Date(now);
        start.setDate(now.getDate() - (dayOfWeek === 0 ? 6 : dayOfWeek - 1));
        start.setHours(0, 0, 0, 0);

        const end = new Date(start);
        end.setDate(start.getDate() + 6);
        end.setHours(23, 59, 59, 999);

        return [start, end];
    }
}
