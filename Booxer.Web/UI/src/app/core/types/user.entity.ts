import { BaseEntity } from "./base.entity";

export interface User extends BaseEntity {
    username: string;
    email: string;
    isAdmin: boolean;
}

export interface UserCreation extends Omit<User, keyof BaseEntity | "isAdmin"> {
    password: string;
}
