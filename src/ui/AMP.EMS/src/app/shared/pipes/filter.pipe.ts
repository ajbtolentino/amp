
import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
    name: 'filter',
    pure: true // Keeps it pure to only re-evaluate when input changes
})
export class FilterPipe implements PipeTransform {

    // The 'transform' method takes an array and a filter function
    transform<T>(items: T[], condition: (item: T) => boolean): T[] {
        if (!items || !condition) {
            return items || []; // Return original array if no condition is provided
        }
        // Apply the custom condition function to filter the array
        return items.filter(condition) || [];
    }
}