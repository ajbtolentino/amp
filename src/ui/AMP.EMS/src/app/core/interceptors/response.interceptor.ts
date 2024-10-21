import { HttpEvent, HttpEventType, HttpInterceptorFn, HttpRequest } from '@angular/common/http';
import { inject } from '@angular/core';
import { MessageService } from 'primeng/api';
import { tap } from 'rxjs';


export const responseInterceptor: HttpInterceptorFn = (req: HttpRequest<any>, next) => {
  const messageService: MessageService = inject(MessageService);

  return next(req).pipe(tap((httpEvent: HttpEvent<any>) => {
    if (httpEvent.type === HttpEventType.Response) {
      switch (req.method) {
        case "POST":
          if (httpEvent.ok) messageService.add({ severity: 'success', summary: 'Successfulhttp', detail: httpEvent.body.message, life: 3000 });
          else messageService.add({ severity: 'error', summary: 'Failed', detail: httpEvent.body.message, life: 3000 });
          break;
        case "PUT":
          if (httpEvent.ok) messageService.add({ severity: 'success', summary: 'Successful', detail: httpEvent.body.message, life: 3000 });
          else messageService.add({ severity: 'error', summary: 'Failed', detail: httpEvent.body.message, life: 3000 });
          break;
        case "DELETE":
          if (httpEvent.ok) messageService.add({ severity: 'success', summary: 'Successful', detail: httpEvent.body.message, life: 3000 });
          else messageService.add({ severity: 'error', summary: 'Failed', detail: httpEvent.body.message, life: 3000 });
          break;
      }
    }
  }));
};
