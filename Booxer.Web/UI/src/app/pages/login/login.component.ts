import { Component, effect, inject } from "@angular/core";
import { ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from "@angular/router";
import { AuthService } from "../../core/services/auth.service";
import { AppRoutes } from "../../core/constants/app-routes";
import { ButtonModule } from 'primeng/button';
import { PasswordModule } from 'primeng/password';
import { FloatLabelModule } from 'primeng/floatlabel';
import { InputTextModule } from 'primeng/inputtext';
import { LogoComponent } from "../../shared/logo/logo.component";

@Component({
	selector: "login",
	templateUrl: "./login.component.html",
	styleUrl: "./login.component.css",
	standalone: true,
	imports: [
        ReactiveFormsModule,
        ButtonModule,
        PasswordModule,
        FloatLabelModule,
        InputTextModule,
        LogoComponent,
    ],
})
export class LoginComponent {

	readonly auth = inject(AuthService);
	readonly router = inject(Router);
	readonly form: FormGroup;

	constructor(private fb: FormBuilder) {
        effect(() => this.auth.user() && this.router.navigate([AppRoutes.DASHBOARD]))

        this.form = this.fb.group({
			usernameOrEmail: ['', [Validators.required]],
			password: ['', [Validators.required]],
		});
	}

	async submit() {
		await this.auth.login(this.form.value);
	}
}
