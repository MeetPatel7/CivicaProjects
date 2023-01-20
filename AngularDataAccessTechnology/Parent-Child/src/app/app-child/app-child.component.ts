import { Component, EventEmitter, OnInit, Output } from '@angular/core';


@Component({
  selector: 'app-child',
  templateUrl: './app-child.component.html',
  styleUrls: ['./app-child.component.css']
})
export class AppChildComponent implements OnInit {

  //ans:number ;
  fnumber: number = 0;
  snumber: number = 0;
  constructor() { }

  @Output() eventadd = new EventEmitter<number>();

  ngOnInit(): void {
  }

  Add()
  {
    this.eventadd.emit(Number(this.fnumber) + Number(this.snumber));
  }

  
}
