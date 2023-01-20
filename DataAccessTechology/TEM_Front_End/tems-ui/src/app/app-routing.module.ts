import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ShowEventDetailsComponent } from './show-event-details/show-event-details.component';
import { ShowEventsComponent } from './show-events/show-events.component';
import { ShowSpeakerDetailComponent } from './show-speaker-detail/show-speaker-detail.component';
import { ShowSpeakersComponent } from './show-speakers/show-speakers.component';
import { ShowVenueComponent } from './show-venue/show-venue.component';

const routes: Routes = [
  { 
    path : '', component:ShowEventsComponent
  },
  {
    path : 'Event', component:ShowEventsComponent
  },
  {
    path : 'Speaker', component:ShowSpeakersComponent
  },
  {
    path : 'Venue/:id', component:ShowVenueComponent
  },
  {
    path : 'EventDetail/:id', component:ShowEventDetailsComponent
  },
  {
    path : 'SpeakerDetail/:id', component:ShowSpeakerDetailComponent
  },
  { 
    path: 'events/:id/authors', component: ShowSpeakersComponent 
  },
  { 
    path: 'events/:id/authors/:sid', component: ShowSpeakerDetailComponent 
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
