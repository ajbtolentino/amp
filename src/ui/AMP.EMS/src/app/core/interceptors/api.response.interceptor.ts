import { HttpEvent, HttpEventType, HttpInterceptorFn, HttpRequest } from '@angular/common/http';
import { inject } from '@angular/core';
import { MessageService } from 'primeng/api';
import { catchError, tap, throwError } from 'rxjs';


export const apiResponseInterceptor: HttpInterceptorFn = (req: HttpRequest<any>, next) => {
  const messageService: MessageService = inject(MessageService);

  const notify = (message: string, success: boolean) => {
    if (success) messageService.add({ severity: 'success', summary: 'Successful', detail: message, life: 3000 });
    else messageService.add({ severity: 'error', summary: 'Failed', detail: message, life: 3000 });
  }

  return next(req).pipe(
    tap((httpEvent: HttpEvent<any>) => {
      if (httpEvent.type === HttpEventType.Response && httpEvent.url?.includes("api")) {
        switch (req.method) {
          case "POST":
            notify(httpEvent.body?.message, httpEvent.ok);
            break;
          case "PUT":
            notify(httpEvent.body?.message, httpEvent.ok);
            break;
          case "DELETE":
            notify(httpEvent.body?.message, httpEvent.ok);
            break;
        }
      }
    }), catchError((error) => {
      if (req.url.includes("api")) {
        const detail = error?.error?.title || 'An error occurred while processing your request.';
        messageService.add({ severity: 'error', summary: 'Error', detail: detail, life: 6000 });
      }
      return throwError(() => error);
    }));
};
