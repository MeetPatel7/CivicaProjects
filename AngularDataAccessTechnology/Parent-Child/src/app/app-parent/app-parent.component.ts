import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-parent',
  templateUrl: './app-parent.component.html',
  styleUrls: ['./app-parent.component.css']
})
export class AppParentComponent implements OnInit {

  result:number = 0;

  constructor() { }

  ngOnInit(): void {
  }

  ViewResult(result: number)
  {
    this.result = result;
  }

}
