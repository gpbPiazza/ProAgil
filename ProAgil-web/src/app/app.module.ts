import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {HttpClientModule} from '@angular/common/http';
import { NavigationComponent } from './navigation/navigation.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import {TooltipModule} from 'ngx-bootstrap/tooltip';
import { ModalModule} from 'ngx-bootstrap/modal';
import { NgxMaskModule } from 'ngx-mask';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { ToastrModule } from 'ngx-toastr';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EventComponent } from './event/event.component';
import { DateTimeFormatPipePipe } from './helpers/DateTimeFormatPipe.pipe';
import { DashboardComponent } from './dashboard/dashboard.component';
import { SpeakersComponent } from './speakers/speakers.component';
import { ContactsComponent } from './contacts/contacts.component';
import {TitleComponent} from './components/title/title.component';
@NgModule({
  declarations: [
    AppComponent,
    EventComponent,
    NavigationComponent,
    DateTimeFormatPipePipe,
		DashboardComponent,
		DashboardComponent,
		SpeakersComponent,
		ContactsComponent,
		TitleComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BsDropdownModule.forRoot(),
    ToastrModule.forRoot(),
    TooltipModule.forRoot(),
    BsDatepickerModule.forRoot(),
    ModalModule.forRoot(),
    NgxMaskModule.forRoot(),
    BrowserAnimationsModule,
    ReactiveFormsModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
