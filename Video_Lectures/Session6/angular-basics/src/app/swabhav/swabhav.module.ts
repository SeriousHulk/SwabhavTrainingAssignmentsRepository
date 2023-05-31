import { NgModule } from '@angular/core';
import { WishComponent } from './wish/wish.component';
import { BrowserModule } from '@angular/platform-browser';
import { SnakePipe } from './snake.pipe';



@NgModule({
  declarations: [
    WishComponent,
    SnakePipe
  ],
  imports: [
    BrowserModule
  ],
  exports :[
    BrowserModule,
    WishComponent,
    SnakePipe
  ]
})
export class SwabhavModule { }
