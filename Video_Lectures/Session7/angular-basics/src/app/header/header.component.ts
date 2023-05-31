import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'pro-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit{
  title = "Monocept"
  location2 = 'hyderabad'
  constructor(){
    console.log("inside constructor");
  }
  ngOnInit(): void {
    console.log("header renfered successfully inside browswe");
    setTimeout(() => {
      this.title = "Swabhav"
      this.location2 = "Andheri"
    }, 3000);
  }
}
