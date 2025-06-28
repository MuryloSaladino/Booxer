import { Injectable } from "@angular/core";
import { Category, CategoryCreation } from "../types/category.entity";
import { api } from "../api";
import { Query } from "../utils/query";

export interface CategoryFilter {
    matchName?: string;
}

@Injectable({ providedIn: "root" })
export class CategoryService {

	async create(categoryCreation: CategoryCreation) {
		const response = await api.post<Category>("/categories", categoryCreation);
        return response.data;
	}

	async getAll(filter: CategoryFilter = {}) {
		const response = await api.get<Category[]>("/categories" + new Query(filter));
        return response.data;
	}
}
