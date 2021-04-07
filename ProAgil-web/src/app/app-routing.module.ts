import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ContactsComponent } from './contacts/contacts.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { EventComponent } from './event/event.component';
import { SpeakersComponent } from './speakers/speakers.component';

const routes: Routes = [
  { path: 'events', component: EventComponent},
  { path: 'dashboard', component: DashboardComponent},
  { path: 'speakers', component: SpeakersComponent},
  { path: 'contacts', component: ContactsComponent},
	{ path: '', redirectTo: 'dashboard', pathMatch: 'full'},
  { path: '**', redirectTo: 'dashboard', pathMatch: 'full'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
