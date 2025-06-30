import { Component, inject, OnInit } from "@angular/core";
import { Router, RouterModule } from "@angular/router";
import { AuthService } from "../../core/services/auth.service";
import { AppRoutes } from "../../core/constants/app-routes";
import { AvatarModule } from 'primeng/avatar';
import { LogoComponent } from "../logo/logo.component";
import { ButtonModule } from "primeng/button";
import { MenuModule } from 'primeng/menu';
import { MenuItem } from "primeng/api";
import { ToastModule } from 'primeng/toast';

@Component({
    selector: "app-layout",
    templateUrl: "./layout.component.html",
    styleUrl: "./layout.component.css",
    standalone: true,
    imports: [
        RouterModule,
        AvatarModule,
        LogoComponent,
        ButtonModule,
        MenuModule,
        ToastModule,
    ],
})
export class LayoutComponent implements OnInit {

    menuItems: MenuItem[] = [];

    readonly auth = inject(AuthService);
    readonly router = inject(Router);

    ngOnInit() {
        this.menuItems = [
            {
                label: `Username: ${this.auth.user()?.username}`,
                items: [
                    {
                        label: "My Reservations",
                        icon: "pi pi-calendar",
                        routerLink: "/calendar",
                    },
                    { separator: true },
                    {
                        label: "Profile",
                        icon: "pi pi-user",
                    },
                    {
                        label: "Settings",
                        icon: "pi pi-cog",
                    },
                    {
                        label: "Logout",
                        icon: "pi pi-sign-out",
                        command: async () => {
                            await this.auth.logout();
                            this.router.navigate([AppRoutes.LOGIN]);
                        }
                    },
                ]
            },
        ]
    }
}
