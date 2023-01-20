import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ShowEventsComponent } from './show-events/show-events.component';
import { ShowSpeakersComponent } from './show-speakers/show-speakers.component';
import { ShowEventDetailsComponent } from './show-event-details/show-event-details.component';
import { ShowVenueComponent } from './show-venue/show-venue.component';
import { HttpClientModule }from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { ShowSpeakerDetailComponent } from './show-speaker-detail/show-speaker-detail.component';

@NgModule({
  declarations: [
    AppComponent,
    ShowEventsComponent,
    ShowSpeakersComponent,
    ShowEventDetailsComponent,
    ShowVenueComponent,
    ShowSpeakerDetailComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
