import { inject, Injectable } from "@angular/core";
import { Category, CategoryCreation } from "../types/category.entity";
import { Query } from "../utils/query";
import { ApiService, RequestOptions } from "./api.service";

export interface CategoryFilter {
    matchName?: string;
}

@Injectable({ providedIn: "root" })
export class CategoryService {

    readonly api = inject(ApiService);

	async create(categoryCreation: CategoryCreation, options?: RequestOptions) {
		const response = await this.api.post<Category>("/categories", categoryCreation, options);
        return response.data;
	}

	async getAll(filter: CategoryFilter = {}, options?: RequestOptions) {
		const response = await this.api.get<Category[]>("/categories" + new Query(filter), options);
        return response.data;
	}
}
