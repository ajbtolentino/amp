export function formatCurrency(
    value: number,
    locale: string = 'en-US',
    currencyCode: string = 'USD',
    currencyDisplay: 'symbol' | 'code' | 'name' = 'symbol',
): string {
    return new Intl.NumberFormat(locale, {
        style: 'currency',
        currency: currencyCode,
        currencyDisplay: currencyDisplay,
    }).format(value);
}
