import { Component, OnInit } from '@angular/core';
import { ProductService } from './product.service';
import { Product } from './product';

@Component({
  selector: 'sw-product-list',
  templateUrl: './product.list.component.html',
})
export class ProductListComponent implements OnInit {
  products:Product[]=[]
constructor(private productService:ProductService){

}
ngOnInit(): void {
  this.products = this.productService.getProducts()
}
}
