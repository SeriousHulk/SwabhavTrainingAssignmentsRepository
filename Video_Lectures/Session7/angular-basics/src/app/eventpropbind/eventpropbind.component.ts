import { Component } from '@angular/core';

@Component({
  selector: 'pro-eventpropbind',
  templateUrl: './eventpropbind.component.html',
  styleUrls: ['./eventpropbind.component.css']
})
export class EventpropbindComponent {
  title = 'this is event() and property[] binding app'
  count =0
  divColor = "black"
  clickHandler(){
    this.count += 1;
    if(this.count ==10)
    {
      alert('limit crossed!')
      this.count =0;
    }
  }
  changeDivColor(color:string){
    this.divColor = color
  }
}
