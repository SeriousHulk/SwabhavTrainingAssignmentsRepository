import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgToastService } from 'ng-angular-popup';
import { Contact } from 'src/app/model/contact.model';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'app-contact-by-id',
  templateUrl: './contact-by-id.component.html',
  styleUrls: ['./contact-by-id.component.css']
})
export class ContactByIdComponent {
  public contact:Contact
  constructor(private route:ActivatedRoute,private api:ApiService,private toast:NgToastService
    ,private router:Router){

  }
  ngOnInit(): void {
    this.route.paramMap.subscribe(
      {
        next:(params)=>{
          const id = params.get('id');
          if(id){
            this.api.getContactById(id)
            .subscribe({
              next:(res=>{
                 this.contact=res;
              }),
              error:(err=>{
                this.toast.error({detail:"ERROR",summary:err?.error.message,duration:5000})
              })
            }); 
          }
        }
      })
    }
}
