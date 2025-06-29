import { Component } from "@angular/core";
import { ButtonModule } from "primeng/button";
import { OverlayPanelModule } from 'primeng/overlaypanel';

@Component({
    selector: "reservation-rules",
    templateUrl: "./reservation-rules.component.html",
    styleUrl: "./reservation-rules.component.css",
    standalone: true,
    imports: [
        OverlayPanelModule,
        ButtonModule,
    ],
})
export class ReservationRulesComponent {

}
