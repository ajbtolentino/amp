import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
    name: 'reduce',
})
export class ReducePipe implements PipeTransform {
    transform<T>(array: T[], callback: (acc: any, curr: T) => any, initialValue: any): any {
        return array.reduce(callback, initialValue);
    }
}