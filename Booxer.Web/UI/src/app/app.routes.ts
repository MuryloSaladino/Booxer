import { Routes } from '@angular/router';
import { AppRoutes } from './core/constants/app-routes';
import { NotFoundComponent } from './pages/not-found/not-found.component';
import { LoginComponent } from './pages/login/login.component';
import { authGuard } from './core/guards/auth.guard';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { LayoutComponent } from './shared/layout/layout.component';
import { ReservationComponent } from './pages/reservation/reservation.component';
import { CalendarComponent } from './pages/calendar/calendar.component';

export const routes: Routes = [
    {
		path: "",
		redirectTo: AppRoutes.LOGIN,
		pathMatch: 'full',
	},
	{
		path: AppRoutes.NOT_FOUND,
		component: NotFoundComponent,
	},
	{
		path: AppRoutes.LOGIN,
		component: LoginComponent,
	},
    {
		path: "",
        component: LayoutComponent,
		canActivate: [authGuard],
		children: [
			{
				path: AppRoutes.DASHBOARD,
                component: DashboardComponent,
			},
            {
                path: AppRoutes.RESERVATION + '/:resourceId',
                component: ReservationComponent,
            },
            {
                path: AppRoutes.CALENDAR,
                component: CalendarComponent,
            }
		]
	},
	{
		path: "**",
		redirectTo: AppRoutes.NOT_FOUND,
	},
];
