import { Injectable } from "@angular/core";
import { Reservation, ReservationCreation } from "../types/reservation.entity";
import { api } from "../api";
import { Query } from "../utils/query";

export interface ReservationFilter {
    categoryId?: string;
    resourceId?: string;
    start?: Date;
    end?: Date;
}

@Injectable({ providedIn: "root" })
export class ReservationService {

    async create(reservationCreation: ReservationCreation) {
        await api.post("/reservations", reservationCreation);
    }

    async getAll(filter: ReservationFilter = {}) {
        const response = await api.get<Reservation[]>("/reservations" + new Query(filter));
        return response.data;
    }

    async delete(reservationId: string) {
        await api.delete("/reservations/" + reservationId);
    }
}
