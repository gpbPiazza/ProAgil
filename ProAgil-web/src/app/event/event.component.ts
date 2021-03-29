import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import {API_URL_DEVELOP_IMAGES, API_URL_DEVELOP} from '../../config/constants';

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

  private apiUrl: string = API_URL_DEVELOP;
  private _eventsFilter: string = '';
  public apiUrlImages: string = API_URL_DEVELOP_IMAGES;
  public imageWidth: number = 60;
  public imageMargin: number = 10;
  public showImage: boolean = false;
  public events: any;
  public eventsFiltered: Event[] = [];

  constructor(private http: HttpClient) { }
  ngOnInit(): void {
    this.getEvents();
  }

  toggleShowImage(): void {
    this.showImage = !this.showImage;
  }

  getEvents(): void {
    this.http.get<Event[]>(this.apiUrl).subscribe(
      response => {
        this.eventsFiltered = response;
        this.events = response;
      },
      error => console.log(error)
    );
  }

  get eventsFilter(): string {
    return this._eventsFilter;
  }

  set eventsFilter(theme: string) {
    this._eventsFilter = theme;
    this.eventsFiltered = this._eventsFilter ? this.filterEvents(this._eventsFilter) : this.events;
  }

  filterEvents(filterBy: string): Event {
    filterBy = filterBy.toLocaleLowerCase();
    return this.events.filter(
      (event: { theme: string; }) => event.theme.toLocaleLowerCase().indexOf(filterBy) !== -1
    );
  }
}
