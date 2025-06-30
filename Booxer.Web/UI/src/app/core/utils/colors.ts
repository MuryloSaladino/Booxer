export function toHex(r: number, g: number, b: number): string {
    return ('#' + [r, g, b]
        .map((x) => {
            const hex = x.toString(16);
            return hex.length === 1 ? '0' + hex : hex;
        }).join('')
    )
}

export function darken(r: number, g: number, b: number, factor = 0.3) {
    function clamp(val: number, min = 0, max = 255): number {
        return Math.min(max, Math.max(min, val));
    }

    return {
        r: clamp(r * (1 - factor)),
        g: clamp(g * (1 - factor)),
        b: clamp(b * (1 - factor)),
    };
}

export function getContrastText(r: number, g: number, b: number): string {
    const luminance = 0.299 * r + 0.587 * g + 0.114 * b;
    return luminance > 186 ? '#000000' : '#FFFFFF';
}

export function generateEventColorFromString(seed: string) {
    function hashCode(str: string): number {
        let hash = 0;
        for (let i = 0; i < str.length; i++) {
            hash = str.charCodeAt(i) + ((hash << 5) - hash);
        }
        return hash;
    }

    const hash = hashCode(seed);
    const r = 120 + (hash & 0x1f); // 120–255
    const g = 120 + ((hash >> 5) & 0x1f);
    const b = 120 + ((hash >> 10) & 0x1f);

    const primary = toHex(r, g, b);

    const { r: dr, g: dg, b: db } = darken(r, g, b);
    const secondary = toHex(dr, dg, db);

    return { primary, secondary, secondaryText: secondary };
}
