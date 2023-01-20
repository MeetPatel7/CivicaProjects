import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ISpeaker } from '../ispeaker';
import { SpeakerService } from '../speaker.service';

@Component({
  selector: 'app-show-speakers',
  templateUrl: './show-speakers.component.html',
  styleUrls: ['./show-speakers.component.scss']
})
export class ShowSpeakersComponent implements OnInit {

  speakerData !: ISpeaker[];
  eventId !: any;
  speakerId !: any;

  constructor(private speakerService : SpeakerService, private route : ActivatedRoute)  { }

  ngOnInit(): void {
    this.eventId = this.route.snapshot.paramMap.get("id");
    this.viewSpeaker();
    this.speakerId = this.route.snapshot.paramMap.get("sid");
  }

  viewSpeaker(){
    this.speakerService.getSpeaker(this.eventId).subscribe(
      data => {
        this.speakerData = data;
      }
    )
  }

}
