import axios from "axios";
import { environment } from "../../../environments/environment";

const api = axios.create({
    baseURL: environment.apiUrl,
    timeout: 20000,
    headers: { "Content-Type": "application/json" },
    withCredentials: true,
});

export { api }
