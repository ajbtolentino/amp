import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
    name: 'jsonParse',
})
export class JsonParsePipe implements PipeTransform {
    transform(value: string | undefined | null): any {
        try {
            if (!value) return {};

            return JSON.parse(value);
        } catch (e) {
            console.error('Invalid JSON string:', e);
            return null;
        }
    }
}
