import { Component, OnInit } from '@angular/core';
import { ProductService } from '../product/product.service';

@Component({
  selector: 'app-twowaybind',
  templateUrl: './twowaybind.component.html'
})
export class TwowaybindComponent implements OnInit {
  constructor(public service :ProductService){
    
  }
  firstName = "Vikrant"
  lastName = "Kadam"
  ngOnInit(): void {
    console.log(this.service.getById(101));
  }
}
