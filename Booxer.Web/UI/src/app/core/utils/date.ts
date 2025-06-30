export function mergeDateAndTime(date: Date, time: Date): Date {
    const merged = new Date(date);
    merged.setHours(time.getHours());
    merged.setMinutes(time.getMinutes());
    merged.setSeconds(time.getSeconds());
    merged.setMilliseconds(time.getMilliseconds());
    return merged;
}

export function isDateInHourRange(date: Date, minHour: number, maxHour: number): boolean {
    const hour = date.getHours();
    return hour >= minHour && hour < maxHour;
}

