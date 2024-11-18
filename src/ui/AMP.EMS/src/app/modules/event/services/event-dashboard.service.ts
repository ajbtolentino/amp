import { Injectable } from '@angular/core';
import { BaseApiService } from '@core/services/base.api.service';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class EventDashboardService extends BaseApiService {
    guestInvitations = (eventId: string): Observable<any> => {
        return this.httpGet<any>(`dashboard/${eventId}/guestinvitations`);
    }

    budget = (eventId: string): Observable<any> => {
        return this.httpGet<any>(`dashboard/${eventId}/budget`);
    }

    expenses = (eventId: string): Observable<any> => {
        return this.httpGet<any>(`dashboard/${eventId}/expenses`);
    }
}