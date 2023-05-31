import { Component } from '@angular/core';
import {HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  constructor(private http:HttpClient){

  }
  loadCustomers(){
    console.log("btn click fired");
    this.http.get('http://localhost:5454/api/v1/customer/GetAllCustomers')
    .subscribe((d)=>console.log(d))
  }
  addCustomers(){
    console.log("Add Customer clicked");
    this.http.post("http://localhost:5454/api/v1/customer/AddCustomer",{
      Id:5,
      Name:"Manjunath"
    }).subscribe(()=>console.log("Customer Added Successfully."));
  }
}