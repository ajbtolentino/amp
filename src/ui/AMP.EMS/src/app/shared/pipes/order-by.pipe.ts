// order-by.pipe.ts
import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
    name: 'orderBy'
})
export class OrderByPipe<T> implements PipeTransform {
    transform(items: T[], key: keyof T, order: 'asc' | 'desc' = 'asc'): T[] {
        if (!items || !key) return items;

        const sortedItems = [...items].sort((a, b) => {
            const aValue = a[key];
            const bValue = b[key];

            if (aValue === bValue) return 0;

            const comparison = aValue < bValue ? -1 : 1;
            return order === 'asc' ? comparison : -comparison;
        });

        return sortedItems;
    }
}
