export function toLocalISOString(date: Date): string {
    const pad = (n: number) => n.toString().padStart(2, '0');
    return `${date.getFullYear()}-${pad(date.getMonth() + 1)}-${pad(date.getDate())}T` +
           `${pad(date.getHours())}:${pad(date.getMinutes())}:${pad(date.getSeconds())}`;
}


export function serializeRequestData(data: any): any {
    if (data === null || data === undefined) {
        return data;
    }

    if (data instanceof Date) {
        return toLocalISOString(data);
    }

    if (Array.isArray(data)) {
        return data.map(serializeRequestData);
    }

    if (typeof data === 'object') {
        const result: any = {};
        for (const key in data) {
            if (Object.prototype.hasOwnProperty.call(data, key)) {
                result[key] = serializeRequestData(data[key]);
            }
        }
        return result;
    }

    return data;
}
