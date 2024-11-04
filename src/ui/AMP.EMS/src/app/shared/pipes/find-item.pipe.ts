import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
    name: 'findItem'
})
export class FindItemPipe<T> implements PipeTransform {
    transform(items: T[], value: any, key: keyof T): T | undefined | {} {
        return items.find(item => item[key] === value) ?? {};
    }
}