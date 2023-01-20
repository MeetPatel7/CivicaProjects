import { Component, OnInit } from '@angular/core';
import { EventService } from '../event.service';
import { IEvent } from '../ievent';

@Component({
  selector: 'app-show-events',
  templateUrl: './show-events.component.html',
  styleUrls: ['./show-events.component.scss']
})
export class ShowEventsComponent implements OnInit {

  eventData !: IEvent[];
  event : any;

  constructor(private eventService:EventService) { }

  ngOnInit(): void {
    this.viewEvent();
    //this.viewEventIsNotCompleted();
  }

  viewEvent(){
    this.eventService.getEvent().subscribe(
      data => {
        this.eventData = data;
      }
    )
  }

  viewEventIsNotCompleted(){
    this.eventService.getEvent().subscribe(
      data => {
        this.eventData = data;
        this.event = data[this.eventData.findIndex(x => x.isCompleted == false)];
      }
    )
  }

  // onSubmit(form: NgForm) {
  //   if (this.service.employeeFormData.id == 0)
  //     this.insertRecord(form);

  //   else
  //     form.value.dateOfBirth;
  //     form.value.joinedDate=new Date();
  //     this.updateRecord(form);
  // }
}
