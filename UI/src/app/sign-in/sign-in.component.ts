import { Component, OnInit } from '@angular/core';
import { HttpService } from '../http.service';
import { NgForm } from '@angular/forms';
import { Cart } from '../models/cart';
import { ToasterService } from 'angular2-toaster';
import { Router } from '@angular/router';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class SignInComponent implements OnInit {

  getUserData = {}
  isCreated : boolean = false;
  isDuplicated : boolean = false;
  isError : boolean = false;
  public cart: Cart;
  


  constructor(private _http: HttpService, private toasterService : ToasterService, private router: Router) {
this.cart = new Cart();
}

  ngOnInit() {
    
  }

  onSubmit(args: NgForm) {
    this.cart.Username = args.value.Username;
    this.cart.ListPC = [];
    this.addUser();
  }

  addUser() {
    this._http.postObject(this.getUserData,"postuser")
    .subscribe(
      res => {
        
        this.isCreated = true;
        this.isDuplicated = false;
        this.isError = false;
        this._http.postObject(this.cart,"postcart").subscribe(
          res=>{
            console.log(res);
            console.log(this._http.getObject("getcart",this.cart.Username));
          },
          err =>{
            console.log(err);
          }
        );

        this.popToast('User added Succesfully');
        this.router.navigate(['/log-in']);
      },
      err => {
        
        this.getUserData = {};
        if(err.status == 417){
          this.isDuplicated =  true;
          this.isCreated = false;
          this.isError = false;
          
        } else {
          this.isError = true;
          this.isCreated = false;
          this.isDuplicated = false;
        }
      }
    )
  }

  popToast(message : string) {
    this.toasterService.pop('success', 'DONE', message);
  }

}
