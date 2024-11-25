// src/app/shared/utils/date-utils.ts
export function removeTimezoneOffset(date: Date | string | null): Date | null {
    if (!date) {
        return null;
    }
    const inputDate = typeof date === 'string' ? new Date(date) : date;
    return new Date(inputDate.getTime() - inputDate.getTimezoneOffset() * 60000);
}