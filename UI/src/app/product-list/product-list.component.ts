import { Component, OnInit } from '@angular/core';
import { HttpService } from '../http.service';
import { Product } from '../models/product';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
  constructor(private _http: HttpService) { }
  products: Product[]
  /*products: any[] = [
    {imageUrl:"https://picsum.photos/200/300/?random",price:1,description:"description",name:"name",code:"1026"},
    {imageUrl:"https://picsum.photos/200/300/?random",price:1,description:"description",name:"name",code:"1026"},
    {imageUrl:"https://picsum.photos/200/300/?random",price:1,description:"description",name:"name",code:"1026"},
    {imageUrl:"https://picsum.photos/200/300/?random",price:1,description:"description",name:"name",code:"1026"},
    {imageUrl:"https://picsum.photos/200/300/?random",price:1,description:"description",name:"name",code:"1026"},
    {imageUrl:"https://picsum.photos/200/300/?random",price:1,description:"description",name:"name",code:"1026"},
    {imageUrl:"https://picsum.photos/200/300/?random",price:1,description:"description",name:"name",code:"1026"},
    {imageUrl:"https://picsum.photos/200/300/?random",price:1,description:"description",name:"name",code:"1026"},
    {imageUrl:"https://picsum.photos/200/300/?random",price:1,description:"description",name:"name",code:"1026"},
    {imageUrl:"https://picsum.photos/200/300/?random",price:1,description:"description",name:"name",code:"1026"},
    {imageUrl:"https://picsum.photos/200/300/?random",price:1,description:"description",name:"name",code:"1026"},
    {imageUrl:"https://picsum.photos/200/300/?random",price:1,description:"description",name:"name",code:"1026"}
  ]*/
  ngOnInit() {
    this.getAllProducts()
  }
  getAllProducts(){
    this._http.getObject("getproducts",null).subscribe(
      res=>{
        console.log(res)
        this.products = res;
      },
      err=>{
        console.log(err)
      });
  }
}
