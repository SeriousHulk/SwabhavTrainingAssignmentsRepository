import { Component } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html'
})
export class HomeComponent {
  showImage = false;

  toggleImage() {
    this.showImage = !this.showImage;
  }
}
