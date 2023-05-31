import { Injectable } from '@angular/core';
import { Product } from './product';

@Injectable()
export class ProductService {
  products:Array<Product> = new Array<Product>()
  constructor() { 
    console.log("Product service created");
    this.products.push(new Product(100,"Speaker",999))
    this.products.push(new Product(101,"NewsPaper",3))
    this.products.push(new Product(102,"ToothBrush",34))
  }
  getProducts():Array<Product>{
    return this.products
  }
  getById(id:number){
    let p = this.products.find(p=>p.id==id)
    
    return p
  }
}
