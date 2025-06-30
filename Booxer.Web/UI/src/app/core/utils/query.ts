import { serializeRequestData } from "./serializer";

export class Query {

    readonly params: object;

    constructor(params: object) {
        this.params = serializeRequestData(params);
    }

    toString() {
        return "?" + Object.entries(this.params)
            .map(([key, param]) => {
                const formattedValue = param instanceof Date
                    ? param.toISOString()
                    : String(param);
                return `${key}=${encodeURIComponent(formattedValue)}`;
            })
            .join('&');
    }

    valueOf(): string {
        return this.toString();
    }
}
