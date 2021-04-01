import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {HttpClientModule} from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EventComponent } from './event/event.component';
import { NavigationComponent } from './navigation/navigation.component';
import { FormsModule } from '@angular/forms';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { DateTimeFormatPipePipe } from './helpers/DateTimeFormatPipe.pipe';

@NgModule({
  declarations: [
    AppComponent,
    EventComponent,
    NavigationComponent,
    DateTimeFormatPipePipe
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BsDropdownModule.forRoot(),
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
