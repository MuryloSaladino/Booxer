import { Component, HostBinding, Input, OnInit } from "@angular/core";
import { Reservation } from "../../core/types/reservation.entity";
import { DividerModule } from "primeng/divider";
import { CommonModule } from "@angular/common";

@Component({
    selector: 'reservation-details',
    templateUrl: './reservation-details.component.html',
    styleUrl: './reservation-details.component.css',
    standalone: true,
    imports: [
        DividerModule,
        CommonModule,
    ],
})
export class ReservationDetailsComponent implements OnInit {

    @Input() reservation?: Reservation;
    @Input() start!: Date;
    @Input() end!: Date;
    @Input() resource!: string;

    ngOnInit() {
        if(this.reservation) {
            this.start = this.reservation.startsAt;
            this.end = this.reservation.endsAt;
            this.resource = this.reservation.resource.name;
        }
    }
}
