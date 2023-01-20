import { Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';

@Component({
  selector: 'app-star',
  templateUrl: './star.component.html',
  styleUrls: ['./star.component.scss']
})
export class StarComponent implements OnInit, OnChanges {

  @Input() rating = 0;
  @Output() ratingClicked: EventEmitter<string> = new EventEmitter<string>();
  constructor() { }

  ngOnInit(): void {
    console.log(this.rating);
  }

  ngOnChanges(changes: SimpleChanges): void {

  }

  onClick() {
    this.ratingClicked.emit(`The rating ${this.rating} is clicked`);
  }

}
