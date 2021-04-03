import { Component, OnInit, TemplateRef } from '@angular/core';
import {API_URL_DEVELOP_IMAGES, API_URL_DEVELOP} from '../config/constants';
import { EventService } from '../services/event.service';
import {Event} from '../models/Event';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';

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
  public loading: boolean = false;
  public events: Event[] = [];
  public eventsFiltered: Event[] = [];
  public modalRef!: BsModalRef;

  constructor(
    private eventService: EventService,
    private modalService: BsModalService
    ) { }

  ngOnInit(): void {
    this.getEvents();
  }

  toggleShowImage(): void {
    this.showImage = !this.showImage;
  }

  toggleLoading(): void {
    this.loading = !this.loading;
  }

  getEvents(){
    this.toggleLoading();
    this.eventService.getEvents().subscribe(
      (response: Event[] | any) => {
        this.eventsFiltered = response;
        this.events = response;
      },
      error => console.log(error)
    );
    this.toggleLoading();
  }

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }

  get eventsFilter(): string {
    return this._eventsFilter;
  }

  set eventsFilter(theme: string) {
    this._eventsFilter = theme;
    this.eventsFiltered = this._eventsFilter ? this.filterEvents(this._eventsFilter) : this.events;
  }

  filterEvents(filterBy: string): Event[] {
    filterBy = filterBy.toLocaleLowerCase();
    return this.events.filter(
      (event: { theme: string; }) => event.theme.toLocaleLowerCase().indexOf(filterBy) !== -1
    );
  }
}
