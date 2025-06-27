import { Injectable, signal } from '@angular/core';
import { User } from '../types/user.entity';
import { api } from '../api';

export interface LoginRequest {
    usernameOrEmail: string;
    password: string;
}

@Injectable({ providedIn: 'root' })
export class AuthService {

	readonly user = signal<User | null>(null);

    constructor() {
        try {
		    this.fetchUser();
        } catch {}
    }

	async login(request: LoginRequest) {
		await api.post('/auth/login', request);
		await this.fetchUser();
	}

	async fetchUser() {
        const response = await api.get<User>('/auth/user');
        this.user.set(response.data);
	}

	async logout() {
		await api.delete('/auth/logout');
		this.user.set(null);
	}
}
