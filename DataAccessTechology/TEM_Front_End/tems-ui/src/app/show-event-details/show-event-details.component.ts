import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EventService } from '../event.service';
import { IEvent } from '../ievent';
import { IVenue } from '../ivenue';
import { VenueService } from '../venue.service';

@Component({
  selector: 'app-show-event-details',
  templateUrl: './show-event-details.component.html',
  styleUrls: ['./show-event-details.component.scss']
})
export class ShowEventDetailsComponent implements OnInit {

  venueId !: number;
  eventData !: IEvent[];
  event: any;
  eventDays !: number;
  eventId !: any;
  venueData !: IVenue[];

  constructor(private eventService: EventService, private route: ActivatedRoute,
    private venueService: VenueService) { }

  ngOnInit(): void {
    this.eventId = this.route.snapshot.paramMap.get('id');
    console.log(this.eventId);
    this.viewEvents();
    console.log(this.event);
  }

  viewEvents() {
    this.eventService.getEvent().subscribe(
      data => {
        this.eventData = data;
        this.event = data[this.eventData.findIndex(x => x.id == this.eventId)];
        this.eventDays = this.Days(this.event.startDate, this.event.endDate)
      }
    );
  }

  Days(startDate: Date, endDate: Date): number {
    var startDate = new Date(startDate);
    var endDate = new Date(endDate);
    var Time = endDate.getTime() - startDate.getTime();
    return (Time / (1000 * 3600 * 24)) + 1;
  }
}
