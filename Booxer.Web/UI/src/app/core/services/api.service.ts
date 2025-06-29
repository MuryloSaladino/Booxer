import { inject, Injectable } from "@angular/core";
import axios, { AxiosError, AxiosRequestConfig } from "axios";
import { environment } from "../../../environments/environment";
import { MessageService } from "primeng/api";

export type RequestMethod = "post" | "get" | "delete" | "patch" | "put";

export interface RequestOptions extends AxiosRequestConfig {
    errorFeedback?: boolean;
    successFeedback?: {
        message: string;
        details?: string;
    }
}

export interface ErrorResponse {
    message: string;
    details: string | null;
    status: number;
}


@Injectable({ providedIn: "root" })
export class ApiService {

    readonly messages = inject(MessageService);

    private readonly axios = axios.create({
        baseURL: environment.apiUrl,
        timeout: 20000,
        headers: { "Content-Type": "application/json" },
        withCredentials: true,
    });

    private async call<TResponse>(
        method: RequestMethod,
        url: string,
        data?: any,
        options?: RequestOptions
    ) {
        try {
            const response = await this.axios[method]<TResponse>(url, data, options);

            if(options?.successFeedback) {
                this.messages.add({
                    severity: "success",
                    summary: options.successFeedback.message,
                    detail: options.successFeedback.details,
                });
            }

            return response;

        } catch (e) {
            const error = e as AxiosError<ErrorResponse>;

            if(options?.errorFeedback) {
                this.messages.add({
                    severity: "error",
                    summary: error.response?.data.message || "Internal server error",
                    detail: error.response?.data.details || undefined,
                });
            }
            throw e;
        }
    }

    async post<TResponse>(url: string, data?: any, options?: RequestOptions) {
        return this.call<TResponse>("post", url, data, options);
    }
    async patch<TResponse>(url: string, data?: any, options?: RequestOptions) {
        return this.call<TResponse>("patch", url, data, options);
    }
    async put<TResponse>(url: string, data?: any, options?: RequestOptions) {
        return this.call<TResponse>("put", url, data, options);
    }
    async delete<TResponse>(url: string, options?: RequestOptions) {
        return this.call<TResponse>("delete", url, null, options);
    }
    async get<TResponse>(url: string, options?: RequestOptions) {
        return this.call<TResponse>("get", url, null, options);
    }
}
