import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {API_URL_DEVELOP} from '../config/constants';

@Injectable({
  providedIn: 'root'
})
export class EventService {
  private readonly apiUrl: string = `${API_URL_DEVELOP}/event`;

  constructor(private http: HttpClient) { }

  getEvents(): Observable<Event[]> {
    return this.http.get<Event[]>(`${this.apiUrl}/`);
  }

  getEventById(eventId: number): Observable<Event> {
    return this.http.get<Event>(`${this.apiUrl}/${eventId}`);
  }

  getEventByTheme(theme: string): Observable<Event[]> {
    return this.http.get<Event[]>(`${this.apiUrl}/getByTheme/${theme}`);
  }

  postEvent(event: Event | any) {
    return this.http.post(this.apiUrl, event);
  }

  updateEvent(event: Event | any, eventId: number) {
    return this.http.put(`${this.apiUrl}/${eventId}`, event);
  }

  deleteEventById(eventId: number) {
    return this.http.delete(`${this.apiUrl}/${eventId}`);
  }
}
