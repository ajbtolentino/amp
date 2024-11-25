import { HttpInterceptorFn } from '@angular/common/http';
import { removeTimezoneOffset } from '@shared/utils';

export const dateInterceptor: HttpInterceptorFn = (req, next) => {
    const processDates = (data: any): any => {
        if (!data || typeof data !== 'object') return data;

        if (data instanceof Date) return removeTimezoneOffset(data);

        if (Array.isArray(data)) return data.map(item => processDates(item));

        const processedObject: any = {};
        for (const key of Object.keys(data)) {
            processedObject[key] = processDates(data[key]);
        }
        return processedObject;
    };

    // Process the request body to adjust dates
    const modifiedBody = processDates(req.body);

    // Clone the request with the modified body
    const modifiedRequest = req.clone({ body: modifiedBody });

    return next(modifiedRequest);
};
