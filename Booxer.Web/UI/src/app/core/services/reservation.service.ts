import { inject, Injectable } from "@angular/core";
import { Reservation, ReservationCreation } from "../types/reservation.entity";
import { Query } from "../utils/query";
import { ApiService, RequestOptions } from "./api.service";

export interface ReservationFilter {
    categoryId?: string;
    resourceId?: string;
    reservedById?: string;
    start?: Date;
    end?: Date;
}

@Injectable({ providedIn: "root" })
export class ReservationService {

    readonly api = inject(ApiService);

    async create(reservationCreation: ReservationCreation, options?: RequestOptions) {
        await this.api.post("/reservations", reservationCreation, options);
    }

    async getAll(filter: ReservationFilter = {}, options?: RequestOptions) {
        const response = await this.api.get<Reservation[]>("/reservations" + new Query(filter), options);
        return response.data;
    }

    async delete(reservationId: string, options?: RequestOptions) {
        await this.api.delete("/reservations/" + reservationId, options);
    }
}
