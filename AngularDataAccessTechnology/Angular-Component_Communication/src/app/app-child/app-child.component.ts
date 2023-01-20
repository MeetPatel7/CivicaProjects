import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-child',
  templateUrl: './app-child.component.html',
  styleUrls: ['./app-child.component.css']
})
export class AppChildComponent implements OnInit {

  message:string = "Massage send";
  @Input() data:string;

  @Output() event = new EventEmitter<string>();

  constructor() { }

  ngOnInit(): void {
  }

  SendData(){
    this.event.emit(this.message);
  }

}
