import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { EventsComponent } from './components/events/events.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { SpeakersComponent } from './components/speakers/speakers.component';
import { ProfileComponent } from './components/profile/profile.component';
import { ContactsComponent } from './components/contacts/contacts.component';

const routes: Routes = [
  {path : 'eventos', component: EventsComponent},
  {path : 'dashboard', component: DashboardComponent},
  {path : 'palestrantes', component: SpeakersComponent},
  {path : 'perfil', component: ProfileComponent},
  {path : 'contatos', component: ContactsComponent},
  {path : '', redirectTo: 'dashboard', pathMatch: 'full' },
  {path : '**', redirectTo: 'dashboard', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
