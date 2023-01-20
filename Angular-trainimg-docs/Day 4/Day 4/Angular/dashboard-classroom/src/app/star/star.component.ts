import { Component, Input, OnChanges, OnInit, SimpleChanges } from '@angular/core';

@Component({
  selector: 'app-star',
  templateUrl: './star.component.html',
  styleUrls: ['./star.component.scss']
})
export class StarComponent implements OnInit, OnChanges {

  @Input() rating = 0;
  constructor() { }

  ngOnInit(): void {
    console.log(this.rating);
  }

  ngOnChanges(changes: SimpleChanges): void {

  }

}
