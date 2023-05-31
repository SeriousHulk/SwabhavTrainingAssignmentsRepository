import { Component, OnInit } from '@angular/core';
import { ApiService } from 'src/app/services/api.service';
import {NgToastService} from 'ng-angular-popup';
import {Router } from '@angular/router';

@Component({
  selector: 'app-show-contacts',
  templateUrl: './show-contacts.component.html',
  styleUrls: ['./show-contacts.component.css']
})
export class ShowContactsComponent implements OnInit{
  public contacts:any[];
  constructor(private api:ApiService,private toast:NgToastService,private router:Router){

  }
  ngOnInit(): void {
    this.api.getContacts()
    .subscribe(res=>{
      console.log(res)
      this.contacts=res;
    })
  }
}
