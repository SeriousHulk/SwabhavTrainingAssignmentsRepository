import { Component } from '@angular/core';

@Component({
  selector: 'app-wish',
  templateUrl: './wish.component.html',
  styleUrls: ['./wish.component.css']
})
export class WishComponent {
  message:string ="hello "
  today:Date = new Date
  wishHandler(user:string){
    this.message+=","+user.toUpperCase()+" all your wishes may come true";
  }
}
