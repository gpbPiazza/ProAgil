import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import {URLS_DEVELOPMENT} from '../../config/constants';

interface Event {
  eventId: number;
  place: string;
  eventDate: string;
  theme: string;
  peopleAmount: number;
  lot: string;
  imageUrl: string;
}

@Component({
    selector: 'app-event',
    templateUrl: './event.component.html',
    styleUrls: ['./event.component.css']
})

export class EventComponent implements OnInit {
    events: any;
    private apiUrl = 'http://localhost:5000/api';

    constructor(private http: HttpClient) { }

    ngOnInit(): void {
      this.getEvents();
    }

    getEvents(): void {
      this.http.get<Event[]>(this.apiUrl).subscribe(
        response => this.events = response,
        error => console.log(error)
      );
    }
}
