import { lastValueFrom } from 'rxjs';
import { BaseService } from './base.service';
import { Rsvp } from '../models/rsvp';

export class RsvpService extends BaseService {
    add = async (rsvp: Rsvp) => {
        return await lastValueFrom(this.http.post<any>(`${this.API_URL}/api/rsvp`, rsvp, { headers: this.headers }));
    }
}