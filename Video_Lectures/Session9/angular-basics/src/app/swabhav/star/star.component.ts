import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'sw-star',
  templateUrl: './star.component.html',
  styleUrls: ['./star.component.css'],
})
export class StarComponent {
  @Input()
  rating: number;

  @Output()
  ratingClicked: EventEmitter<string> = new EventEmitter();

  constructor() {
    this.rating = 5;
  }
  clickHandler(e: Event) {
    console.log('inside click Handler');
    console.log(e);
    this.ratingClicked.emit('The star value is ' + this.rating);
  }
}
