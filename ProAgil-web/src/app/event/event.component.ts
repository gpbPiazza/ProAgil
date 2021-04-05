import { Component, OnInit, TemplateRef } from '@angular/core';
import {API_URL_DEVELOP_IMAGES, API_URL_DEVELOP} from '../config/constants';
import { EventService } from '../services/event.service';
import {Event} from '../models/Event';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { BsLocaleService} from 'ngx-bootstrap/datepicker';
import { defineLocale } from 'ngx-bootstrap/chronos';
import { ptBrLocale } from 'ngx-bootstrap/locale';
defineLocale('pt-br', ptBrLocale);
@Component({
    selector: 'app-event',
    templateUrl: './event.component.html',
    styleUrls: ['./event.component.css']
})

export class EventComponent implements OnInit {

  constructor(
    private eventService: EventService,
    private modalService: BsModalService,
    private formBuilder: FormBuilder,
    private localService: BsLocaleService
    ) {
      this.localService.use('pt-br');
    }

  set eventsFilter(theme: string)  {
    this._eventsFilter = theme;
    this.eventsFiltered = this._eventsFilter ? this.filterEvents(this._eventsFilter) : this.events;
  }

  get  eventsFilter(): string  {
    return this._eventsFilter;
  }

  private _eventsFilter: string = '';
  public apiUrlImages: string = API_URL_DEVELOP_IMAGES;
  public imageWidth: number = 60;
  public imageMargin: number = 10;
  public showImage: boolean = false;
  public loading: boolean = false;
  public events: Event[];
  public eventsFiltered: Event[];
  public event: Event;
  public modalRef: BsModalRef;
  public registerForm: FormGroup;
  public eventIdToEdit: number;
  public bodyDeleteEvent: string;
  public isEditEventMode: boolean = false;

  // tslint:disable-next-line: adjacent-overload-signatures
  ngOnInit(): void {
    this.validation();
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

  openModal(template: any) {
    this.registerForm.reset();
    template.show();
  }

  openModalAndDispatchMethod(template: any, isToEdit: boolean, eventId?: number) {
    this.openModal(template);
    this.dispatchMethod(isToEdit, eventId);
  }

  dispatchMethod(isToEdit: boolean, eventId?: number) {
    if (isToEdit && eventId){
      this.isEditEventMode = true;
      this.eventIdToEdit = eventId;
      this.fillFormValue(eventId);
    }else {
      this.isEditEventMode = false;
    }
  }

  validation() {
    const {required, minLength, maxLength, email, max} = Validators;
    this.registerForm = this.formBuilder.group({
      theme: ['', [required, minLength(4), maxLength(50)]],
      place: ['', required],
      eventDate: ['', required],
      peopleAmount: ['', [required, max(12000)]],
      imageUrl: ['', required],
      phoneNumber: ['', required],
      email: ['', [required, email]],
    });
  }

  saveChanges(template: any) {
    if (this.isEditEventMode){
      return this.updateEvent(template);
    }else {
      this.registerEvent(template);
    }
  }

  updateEvent(template: any) {
    if (this.registerForm.valid){
      this.event = Object.assign({}, this.registerForm.value);
      this.eventService.updateEvent(this.event, this.eventIdToEdit).subscribe(
        () => {
          template.hide();
          this.getEvents();
        },
        errors => {
          console.log(errors);
        }
      );
    }
  }

  deleteEvent(event: Event, template: any) {
    this.openModal(template);
    this.event = event;
    this.bodyDeleteEvent = `Tem certeza que deseja excluir o Evento: ${event.theme}, Código: ${event.id}`;
  }


  confirmDelete(template: any){
    console.log(this.event.id);
    this.eventService.deleteEventById(this.event.id).subscribe(
      () => {
        template.hide();
        this.getEvents();
      },
      errors => {
        console.log(errors, 'aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa');
      });
  }

  registerEvent(template: any) {
    if (this.registerForm.valid){
      this.event = Object.assign({}, this.registerForm.value);
      this.eventService.postEvent(this.event).subscribe(
        newEvent => {
          template.hide();
          this.getEvents();
        },
        errors => {
          console.log(errors);
        }
      );
    }
  }

  fillFormValue(eventId: number)  {
    this.eventService.getEventById(eventId).subscribe(
      eventToEdit => {
        this.registerForm.patchValue(eventToEdit);
      },
      errors => {
        console.log(errors);
      }
    );
  }

  filterEvents(filterBy: string )  {
    filterBy = filterBy.toLocaleLowerCase();
    return this.events.filter(
      (event: { theme: string; }) => event.theme.toLocaleLowerCase().indexOf(filterBy) !== -1
    );
  }
}
