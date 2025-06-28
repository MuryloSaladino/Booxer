import { BaseEntity } from "./base.entity";

export interface Resource extends BaseEntity {
    name: string;
    categoryId: string;
}

export type ResourceCreation = Omit<Resource, keyof BaseEntity>;
