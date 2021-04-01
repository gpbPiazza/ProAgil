import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {API_URL_DEVELOP} from '../config/constants';

@Injectable({
  providedIn: 'root'
})
export class EventService {
  private readonly apiUrl: string = API_URL_DEVELOP;

  constructor(private http: HttpClient) { }

  getEvents(): Observable<Event[]> {
    return this.http.get<Event[]>(`${this.apiUrl}/event`);
  }

  getEventById(eventId: number): Observable<Event> {
    return this.http.get<Event>(`${this.apiUrl}/event/${eventId}`);
  }

  getEventByTheme(theme: string): Observable<Event[]> {
    return this.http.get<Event[]>(`${this.apiUrl}/event/getByTheme/${theme}`);
  }
}
