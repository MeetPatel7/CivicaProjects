import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IVenue } from '../ivenue';
import { VenueService } from '../venue.service';

@Component({
  selector: 'app-show-venue',
  templateUrl: './show-venue.component.html',
  styleUrls: ['./show-venue.component.scss']
})
export class ShowVenueComponent implements OnInit {

  venueId : any;
  venueData !:IVenue[];
  venue !: any; 

  constructor(private venueService : VenueService, private route:ActivatedRoute) { }

  ngOnInit(): void {
    this.venueId = this.route.snapshot.paramMap.get("id");
    this.viewVenue();
  }

  viewVenue() {
    this.venueService.getVenue().subscribe(
      data => {
          this.venueData = data;
          this.venue = data[this.venueData.findIndex(x => x.id == this.venueId)];
        }
      );
  }
}
