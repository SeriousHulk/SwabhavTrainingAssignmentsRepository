import { Component } from '@angular/core';

@Component({
  selector: 'app-slider',
  templateUrl: './slider.component.html',
  styleUrls: ['./slider.component.css'],
})
export class SliderComponent {
    selectedValue = 0;
    buttonValues: number[] = [];
  
    updateButtonValues() {
      this.buttonValues = [];
      for (let i = 0; i <= this.selectedValue; i++) {
        this.buttonValues.push(i);
      }
      console.log("Button values:", this.buttonValues);
    }
  
    selectValue(value: number) {
      this.selectedValue = value;
    }
}
