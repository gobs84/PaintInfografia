import { Component, OnInit, ViewContainerRef } from '@angular/core';
import { Cart } from '../models/cart';
import { Store } from '../models/store';
import { Product } from '../models/product';
import { HttpService } from '../http.service';
import { DataSharingService } from '../data-sharing.service';
import { Router, ActivatedRoute } from '@angular/router';
import { ProductCart } from '../models/productCart';
import { CookieService } from 'ngx-cookie-service';
import { User } from '../models/user';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css']
})





export class ProductDetailComponent implements OnInit {

  cookieValue = 'UNKNOWN';
  user: User = new User();
  show: boolean = true;
  state: string = '';
  log: boolean = false;
  text: string = '';
  quantity: number = 0;
  cant: number;
  products: Product[];
  product: Product;
  productCart: ProductCart;
  carrito: Cart;
  identifier: string;
  href: String;
  cad: string[];
  stores: Store[];


  constructor(private _http: HttpService, private router: Router, private id: ActivatedRoute, private allService: HttpService, private _shared: DataSharingService, private cookieService: CookieService) { }
  ngOnInit() {
    this.user.LastName = this.cookieService.get('Lname');
    this.user.Name = this.cookieService.get('Name');
    this.user.Username = this.cookieService.get('User');
    if(this.cookieService.get("User")!="")
    {
      this.log = true;
    }

    console.log("user");
    console.log(this.user.Username);
    console.log(this.user.LastName);
    this.changeInputVar();
    this.getCart(this.user.Username);
    this.getAllProducts();
    this.href = this.router.url;
    this.getId();
  }
  private changeInputVar(): void {
    this.cant = 1;
  }
  getCart(username: string) {
    this.allService.getObject("getCart", username).subscribe(
      response => {
        console.log(response);
        this.carrito = response;
      },
      error => {
        console.log(error);
      }
    );
  }

  getStore() {
    this.allService.getObject("getStore", null).subscribe(
      response => {
        console.log(response);
        this.stores = response;
      },
      error => {
        console.log(error);
      }
    );
  }

  getProductCart() {
    this._http.getObject("getproductCart", this.identifier).subscribe(
      response => {
        console.log(response);
        this.productCart = response;
      },
      error => {
        console.log(error);
      }

    );
  }
  getAllProducts() {
    this._http.getObject("getproducts", null).subscribe(
      res => {
        console.log(res)
        this.products = res;
        this.getSpecific();
      },
      err => {
        console.log(err)
      });
  }
  getSpecific() {
    this.product = this.products.find(i => i.Code == this.identifier);
  }
  onClick() {
    if (this.cant == 0 || this.cant == null || this.cant < 0) {
      this.cant = 1;
      console.log("dato incorrecto");
    } else {
      console.log("HE is buying");

      var data = this.identifier;
      var object = new ProductCart();
      object.ProductCode = this.identifier;
      object.ShippingDeliveryType = this.product.ShippingDeliveryType;
      object.Store = this.getStore[0];
      object.Quantity = this.cant;

      console.log("here is username");
      console.log(this.user.Username);
      console.log("here is my carrito");
      console.log(this.carrito.ListPC);

      this.getCart(this.user.Username);

      var lista = this.carrito.ListPC;
      console.log("this is my lista");
      console.log(lista);

      let pc = lista.find(i => i.ProductCode == this.identifier);

      if (pc == null) {
        console.log("no esta en el carrito");
        lista.push(object);

        let newCart = new Cart();
        newCart.Username = this.user.Username;
        newCart.ListPC = lista;
        this.addCart(newCart);

      } else {

        console.log("si esta");
        lista.forEach(function (element) {
          if (element.ProductCode == object.ProductCode) {
            var value = element.Quantity;
            element.Quantity = value + object.Quantity;
          }
        })
        let newCart = new Cart();
        newCart.Username = this.user.Username;
        newCart.ListPC = lista;
        this.addCart(newCart);
      }
      this.router.navigate(['/product-list']);
    }
  }

  seeCart() {
    console.log(this.carrito.ListPC.length);
  }

  getId() {
    this.cad = this.href.split("/");
    this.identifier = this.cad[this.cad.length - 1];
    console.log(this.id);
  }

  addCart(car: Cart) {
    console.log("this is updating");
    console.log(car);
    this.allService.updateObject(car, "updatecart", this.user.Username).subscribe(
      res => {
        console.log("ok");
      },
      err => {
        console.log("no");
      }
    );
  }
}
