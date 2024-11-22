import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
    name: 'map'
})
export class MapPipe implements PipeTransform {
    transform<T, U>(value: T[], callback: (item: T, index: number, array: T[]) => U): U[] {
        return value?.map(callback);
    }
}