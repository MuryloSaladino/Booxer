import { inject } from "@angular/core";
import { AuthService } from "../services/auth.service";
import { Router } from "@angular/router";
import { AppRoutes } from "../constants/app-routes";

export const authGuard = async () => {

	const auth = inject(AuthService);
	const router = inject(Router);

	return Boolean(auth.user()) || router.parseUrl("/" + AppRoutes.LOGIN);
};
