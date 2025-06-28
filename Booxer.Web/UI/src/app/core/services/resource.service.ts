import { Injectable } from "@angular/core";
import { Resource, ResourceCreation } from "../types/resource.entity";
import { api } from "../api";
import { Query } from "../utils/query";

export interface ResourceFilter {
    categoryId?: string;
}

@Injectable({ providedIn: "root" })
export class ResourceService {

    async create(resourceCreation: ResourceCreation) {
        const response = await api.post<Resource>("/resources", resourceCreation);
        return response.data;
    }

    async getAll(filter: ResourceFilter = {}) {
        const response = await api.get<Resource[]>("/resources" + new Query(filter));
        return response.data;
    }
}
