import { inject } from "@angular/core";
import { AuthService } from "../services/auth.service";
import { Router } from "@angular/router";
import { AppRoutes } from "../constants/app-routes";

export const authGuard = async () => {

	const auth = inject(AuthService);
	const router = inject(Router);

    if(auth.user())
        return true;

    try {
        await auth.fetchUser();
        return true;
    } catch {
        return router.parseUrl("/" + AppRoutes.LOGIN);
    }
};
