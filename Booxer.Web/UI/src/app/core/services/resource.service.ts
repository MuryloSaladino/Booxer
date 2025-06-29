import { inject, Injectable } from "@angular/core";
import { Resource, ResourceCreation } from "../types/resource.entity";
import { Query } from "../utils/query";
import { ApiService, RequestOptions } from "./api.service";

export interface ResourceFilter {
    categoryId?: string;
    search?: string;
}

@Injectable({ providedIn: "root" })
export class ResourceService {

    readonly api = inject(ApiService);

    async create(resourceCreation: ResourceCreation, options?: RequestOptions) {
        const response = await this.api.post<Resource>("/resources", resourceCreation, options);
        return response.data;
    }

    async getAll(filter: ResourceFilter = {}, options?: RequestOptions) {
        const response = await this.api.get<Resource[]>("/resources" + new Query(filter), options);
        return response.data;
    }

    async getById(resourceId: string, options?: RequestOptions) {
        const response = await this.api.get<Resource>("/resources/" + resourceId, options);
        return response.data;
    }
}
