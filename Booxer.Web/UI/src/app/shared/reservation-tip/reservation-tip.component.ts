import { Component } from "@angular/core";
import { ButtonModule } from "primeng/button";
import { OverlayPanelModule } from 'primeng/overlaypanel';

@Component({
    selector: "reservation-tip",
    templateUrl: "./reservation-tip.component.html",
    styleUrl: "./reservation-tip.component.css",
    standalone: true,
    imports: [
        OverlayPanelModule,
        ButtonModule,
    ],
})
export class ReservationTipComponent {

}
