import { inject, Injectable, signal } from '@angular/core';
import { User } from '../types/user.entity';
import { ApiService, RequestOptions } from './api.service';

export interface LoginRequest {
    usernameOrEmail: string;
    password: string;
}

@Injectable({ providedIn: 'root' })
export class AuthService {

    readonly api = inject(ApiService);
	readonly user = signal<User | null>(null);

    constructor() {
        try {
		    this.fetchUser();
        } catch {}
    }

	async login(request: LoginRequest, options?: RequestOptions) {
		await this.api.post('/auth/login', request, options);
		await this.fetchUser();
	}

	async fetchUser(options?: RequestOptions) {
        const response = await this.api.get<User>('/auth/user', options);
        this.user.set(response.data);
	}

	async logout(options?: RequestOptions) {
		await this.api.delete('/auth/logout', options);
		this.user.set(null);
	}
}
