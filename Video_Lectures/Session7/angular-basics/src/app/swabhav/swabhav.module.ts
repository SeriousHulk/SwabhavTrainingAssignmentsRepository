import { NgModule } from '@angular/core';
import { WishComponent } from './wish/wish.component';
import { BrowserModule } from '@angular/platform-browser';
import { SnakePipe } from './snake.pipe';
import { TwowaybindComponent } from './twowaybind/twowaybind.component';
import { FormsModule } from "@angular/forms"
import { ProductService } from './product/product.service';
import { ProductListComponent } from './product/product.list.component';



@NgModule({
  declarations: [
    WishComponent,
    SnakePipe,
    TwowaybindComponent,
    ProductListComponent
  ],
  imports: [
    FormsModule, 
    BrowserModule
  ],
  exports :[
    BrowserModule,
    WishComponent,
    SnakePipe,
    TwowaybindComponent,
    ProductListComponent
  ],
  providers:[ProductService]
})
export class SwabhavModule { }
