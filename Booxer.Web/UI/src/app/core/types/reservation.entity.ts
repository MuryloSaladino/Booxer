import { BaseEntity } from "./base.entity";
import { Resource } from "./resource.entity";

export interface Reservation extends BaseEntity {
    startsAt: Date;
    endsAt: Date;
    resource: Resource;
    reservedBy: string;
}

export interface ReservationCreation {
    startsAt: Date;
    endsAt: Date;
    resourceId: string;
}
