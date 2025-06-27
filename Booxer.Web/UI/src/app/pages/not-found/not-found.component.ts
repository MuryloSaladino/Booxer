import { Component } from "@angular/core";
import { RouterModule } from "@angular/router";
import { AppRoutes } from "../../core/constants/app-routes";
import { ButtonModule } from "primeng/button";

@Component({
	selector: "not-found",
	templateUrl: "./not-found.component.html",
	standalone: true,
	imports: [RouterModule, ButtonModule],
})
export class NotFoundComponent {
	readonly home = ["/", AppRoutes.DASHBOARD];
}
