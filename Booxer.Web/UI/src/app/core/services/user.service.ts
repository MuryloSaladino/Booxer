import { inject, Injectable } from "@angular/core";
import { User, UserCreation } from "../types/user.entity";
import { ApiService, RequestOptions } from "./api.service";

@Injectable({ providedIn: "root" })
export class UserService {

    readonly api = inject(ApiService);

	async create(userCreation: UserCreation, options?: RequestOptions) {
		const response = await this.api.post<User>("/users", userCreation, options);
        return response.data;
	}

	async get(userId: string, options?: RequestOptions) {
		const response = await this.api.get<User>("/users/" + userId, options);
        return response.data;
	}

	async getAll(options?: RequestOptions) {
		const response = await this.api.get<User[]>("/users", options);
        return response.data;
	}
}
