import { Injectable } from "@angular/core";
import { Category, CategoryCreation } from "../types/category.entity";
import { api } from "../api";

@Injectable({ providedIn: "root" })
export class CategoryService {

	async create(categoryCreation: CategoryCreation) {
		const response = await api.post<Category>("/categories", categoryCreation);
        return response.data;
	}

	async getAll(search?: string) {
		const response = await api.get<Category[]>("/categories" + search);
        return response.data;
	}
}
