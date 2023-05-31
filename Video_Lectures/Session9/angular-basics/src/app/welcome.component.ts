import { Component } from '@angular/core';
import { ICustomer } from './customer/ICustomer';
@Component({
  selector: 'pro-welcome',
  templateUrl: './welcome.component.html',
  styleUrls: ['./welcome.component.css'],
})
export class WelcomeComponent {
  message: string;
  customers: ICustomer[] = new Array<ICustomer>();
  currentRatingValue: string = '';
  constructor() {
    this.message = 'This is a message from Welcome Component';
    this.customers.push({ firstName: 'firstName1', lastName: 'lastname1' });
    this.customers.push({ firstName: 'firstName2', lastName: 'lastname2' });
    this.customers.push({ firstName: 'firstName3', lastName: 'lastname3' });
  }

  ratingClickedHandler(dataFromChild: string) {
    console.log('inside ratingclicked handler of parent ');
    console.log(dataFromChild.toUpperCase());
    this.currentRatingValue = dataFromChild;
  }
}
