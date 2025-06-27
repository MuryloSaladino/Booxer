import { Injectable } from "@angular/core";
import { User, UserCreation } from "../types/user.entity";
import { api } from "../api";

@Injectable({ providedIn: "root" })
export class UserService {

	async create(userCreation: UserCreation) {
		const response = await api.post<User>("/users", userCreation);
        return response.data;
	}

	async get(userId: string) {
		const response = await api.get<User>("/users/" + userId);
        return response.data;
	}

	async getAll(filter?: any) {
		const response = await api.get<User[]>("/users" + filter);
        return response.data;
	}
}
