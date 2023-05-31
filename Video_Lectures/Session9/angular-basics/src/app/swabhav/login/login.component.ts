import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'sw-login',
  templateUrl: './login.component.html',
})
export class LoginComponent {
  frmLogin:FormGroup
  constructor(){
    this.frmLogin = new FormGroup({
      'userName':new FormControl('Vikrant',Validators.required),
      'userPassword':new FormControl('',Validators.required)
    })
  }
  submitHandler(){

  }
}
