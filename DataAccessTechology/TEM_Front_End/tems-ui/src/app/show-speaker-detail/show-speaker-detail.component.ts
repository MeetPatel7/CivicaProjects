import { Time } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ISpeaker } from '../ispeaker';
import { ITalkDetail } from '../italk-detail';
import { SpeakerService } from '../speaker.service';
import { TalkdetailService } from '../talkdetail.service';

@Component({
  selector: 'app-show-speaker-detail',
  templateUrl: './show-speaker-detail.component.html',
  styleUrls: ['./show-speaker-detail.component.scss']
})
export class ShowSpeakerDetailComponent implements OnInit {

speakerId !: any;
speakerData !: ISpeaker[];
speaker !: ISpeaker;
eventId !: any;
talkDetailsData !: ITalkDetail[];
time !: number;

  constructor(private speakerService : SpeakerService, private route : ActivatedRoute,
    private talkDetailService : TalkdetailService) { }

  ngOnInit(): void {
    this.eventId = this.route.snapshot.paramMap.get("id");
    this.speakerId = this.route.snapshot.paramMap.get("sid");
    
    this.viewSpeaker();
    this.viewTalkDetail();
  }

  viewSpeaker()
  {
    this.speakerService.getSpeaker(this.eventId).subscribe(
      data => {
        this.speakerData = data;
        this.speaker = data[this.speakerData.findIndex(x => x.id == this.speakerId)];
      }
    )
  }

  viewTalkDetail() {
    this.talkDetailService.getTalkDetails(this.eventId, this.speakerId).subscribe(
        data => {
          this.talkDetailsData = data;
          this.getHours(this.talkDetailsData[0].startTime, this.talkDetailsData[0].endTime);
          console.log(this.talkDetailsData);
        }
      );
  }

  getHours(sTime: Time, eTime: Time) {
    var startTime = new Date();
    var endTime = new Date();
    var startTimeSplit = sTime.toString().split(':');
    var endTimeSplit = eTime.toString().split(':');
    startTime = new Date(startTime.setHours(Number(startTimeSplit[0]), Number(startTimeSplit[1]), Number(startTimeSplit[2]), 0));
    endTime = new Date(endTime.setHours(Number(endTimeSplit[0]), Number(endTimeSplit[1]), Number(endTimeSplit[2]), 0));
    this.time = (Number(endTime) - Number(startTime)) / 3600000;
  }

}
