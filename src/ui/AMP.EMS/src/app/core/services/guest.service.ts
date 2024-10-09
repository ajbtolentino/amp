import { lastValueFrom } from 'rxjs';
import { Guest } from '../models/guest';

import { BaseService } from './base.service';

export class GuestService extends BaseService {
    getAll = async () => {
        return await lastValueFrom(this.http.get<any>(`${this.API_URL}/api/guest`, { headers: this.headers }));
    }

    add = async (invitation: Guest) => {
        return await lastValueFrom(this.http.post<any>(`${this.API_URL}/api/guest`, invitation, { headers: this.headers }));
    }

    update = async (invitation: Guest) => {
        return await lastValueFrom(this.http.put<any>(`${this.API_URL}/api/guest/${invitation.id}`, invitation, { headers: this.headers }));
    }

    delete = async (id: string) => {
        return await lastValueFrom(this.http.delete<any>(`${this.API_URL}/api/guest/${id}`, { headers: this.headers }));
    }
}