import { NgModule } from '@angular/core';
import { WishComponent } from './wish/wish.component';
import { BrowserModule } from '@angular/platform-browser';
import { SnakePipe } from './snake.pipe';
import { TwowaybindComponent } from './twowaybind/twowaybind.component';
import { FormsModule, ReactiveFormsModule } from "@angular/forms"
import { ProductService } from './product/product.service';
import { ProductListComponent } from './product/product.list.component';
import { NumberapiComponent } from './numberapi/numberapi.component';
import { HttpClientModule } from '@angular/common/http';
import { NumberapisvcService } from './numberapi/numberapisvc.service';
import { LoginComponent } from './login/login.component';
import { StarComponent } from './star/star.component';


@NgModule({
  declarations: [
    WishComponent,
    SnakePipe,
    TwowaybindComponent,
    ProductListComponent,
    NumberapiComponent,
    LoginComponent,
    StarComponent
  ],
  imports: [
    FormsModule, 
    BrowserModule,
    HttpClientModule,
    ReactiveFormsModule
  ],
  exports :[
    BrowserModule,
    WishComponent,
    SnakePipe,
    TwowaybindComponent,
    ProductListComponent,
    NumberapiComponent,
    LoginComponent,
    StarComponent
  ],
  providers:[ProductService,
    NumberapisvcService]
})
export class SwabhavModule { }
