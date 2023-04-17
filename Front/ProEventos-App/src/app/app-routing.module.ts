import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { DashboardComponent } from './components/dashboard/dashboard.component';
import { SpeakersComponent } from './components/speakers/speakers.component';

import { EventsComponent } from './components/events/events.component';
import { EventDetailComponent } from './components/events/event-detail/event-detail.component';
import { EventListComponent } from './components/events/event-list/event-list.component';

import { UserComponent } from './components/user/user.component';
import { RegistrationComponent } from './components/user/registration/registration.component';
import { LoginComponent } from './components/user/login/login.component';
import { ProfileComponent } from './components/user/profile/profile.component';

import { ContactsComponent } from './components/contacts/contacts.component';

const routes: Routes = [
  {
    path : 'user', component: UserComponent,
    children : [
      { path : 'login', component: LoginComponent },
      { path : 'registration', component: RegistrationComponent, }
    ]
  },
  {path : 'user/perfil', component: ProfileComponent},
  {path : 'eventos', redirectTo: 'eventos/lista'},
  {
    path : 'eventos', component: EventsComponent,
    children: [
      {path : 'detalhe/:id', component: EventDetailComponent},
      {path : 'detalhe', component: EventDetailComponent},
      {path : 'lista', component: EventListComponent}
    ]
  },
  {path : 'dashboard', component: DashboardComponent},
  {path : 'palestrantes', component: SpeakersComponent},
  {path : 'contatos', component: ContactsComponent},
  {path : '', redirectTo: 'dashboard', pathMatch: 'full' },
  {path : '**', redirectTo: 'dashboard', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
