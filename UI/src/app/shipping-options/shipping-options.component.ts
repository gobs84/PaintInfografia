import { Component, OnInit, ViewChild } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { HttpService } from '../http.service';
import { ShippingAddresses } from '../models/shippingAddresses';
import { Cart } from 'src/app/models/cart';
import { CookieService } from 'ngx-cookie-service';
import { Router } from '@angular/router';
import {ToasterService, ToasterConfig} from 'angular2-toaster';

@Component({
  selector: 'app-shipping-options',
  templateUrl: './shipping-options.component.html',
  styleUrls: ['./shipping-options.component.css']
})
export class ShippingOptionsComponent implements OnInit {

  edit : boolean = false;
  tmpAddress : ShippingAddresses;
  addressess : ShippingAddresses[];
  isCreated : boolean = false;
  isDuplicated : boolean = false;
  isError : boolean = false;
  carrito : Cart;
  public config1 : ToasterConfig = new ToasterConfig({
    positionClass: 'toast-top-right',
    animation: 'fade'
  });

  @ViewChild('form') public contentModal;
  @ViewChild('Identifier') public idInput;

  cuForm: FormGroup;
  constructor(fb: FormBuilder, private allService: HttpService, private cookieService: CookieService, private router: Router, private toasterService: ToasterService) { 
    this.cuForm = fb.group({

      'Identifier': new FormControl('', Validators.required),
      'Line1': new FormControl('', Validators.required),
      'Line2': new FormControl('', Validators.required),
      'City': new FormControl('', Validators.required),
      'Phone': new FormControl('', Validators.required),
      'Zone': new FormControl('', Validators.required),
    });
    this.carrito = {
      Username: "",
      ListPC : []
    }
  }

  ngOnInit() {
    this.getAdressess();
  }

  deliver(){
    
    this.deleteCart();
    this.router.navigate(['/home']);
    this.popToast('Purchase made successfully');
  }

  deleteCart(){
    this.carrito.Username = this.cookieService.get('User');
    this.carrito.ListPC=[];
    this.allService.updateObject(this.carrito,"updatecart",this.carrito.Username).subscribe(
      response => {},
      error => {
        console.log(error);
      }
    );
  }

  editAddress(position : number){
    this.cuForm.patchValue(this.addressess[position]);
    this.cuForm.controls['Identifier'].disable();
    this.edit = true;

  }


  editAddressSave(){
    this.tmpAddress = new ShippingAddresses();
     this.tmpAddress.Identifier = this.cuForm.controls['Identifier'].value;
     this.tmpAddress.Line1 = this.cuForm.controls['Line1'].value;
     this.tmpAddress.Line2 = this.cuForm.controls['Line2'].value;
     this.tmpAddress.City = this.cuForm.controls['City'].value;
     this.tmpAddress.Phone = this.cuForm.controls['Phone'].value;
     this.tmpAddress.Zone = this.cuForm.controls['Zone'].value;
     this.allService.updateObject(this.tmpAddress,"updateshippingaddress",this.tmpAddress.Identifier).subscribe(
       response => {
         this.edit = false;
         let x = this.addressess.findIndex(a => a.Identifier ==this.tmpAddress.Identifier);
         this.addressess[x] = this.tmpAddress;
         this.cuForm.controls['Identifier'].enable();
         this.cuForm.reset();
       },
       error => {
         console.log(error);
       }
     );

  }

  getAdressess(){
    this.allService.getObject("getshippingaddress","").subscribe(
      response => {
        if (response)
        this.addressess = response;

      console.log(response);
      },
      error => {
        console.log(error);
      }
    );

  }

  deleteAddress(position: number){
    console.log("delete");
    this.allService.deleteObject("deleteshippingaddress",this.addressess[position].Identifier).subscribe(
      response => {
        console.log("deleted",response);
        this.addressess.splice(position,1);
      },
      error => {
        console.log(error);
      }
    );
  }

  createAddress(){
    console.log("create");
     this.tmpAddress = new ShippingAddresses();
     this.tmpAddress.Identifier = this.cuForm.controls['Identifier'].value;
     this.tmpAddress.Line1 = this.cuForm.controls['Line1'].value;
     this.tmpAddress.Line2 = this.cuForm.controls['Line2'].value;
     this.tmpAddress.City = this.cuForm.controls['City'].value;
     this.tmpAddress.Phone = this.cuForm.controls['Phone'].value;
     this.tmpAddress.Zone = this.cuForm.controls['Zone'].value;

    this.allService.postObject(this.tmpAddress,"postshippingaddress").subscribe(
      response => {
        console.log("created",response);
        this.getAdressess();
        this.isCreated = true;
        this.isError = false;
        this.isDuplicated = false;
        this.popToast('Address added succesfully');
      },
      error => {
        console.log(error);
        if(error.status == 417)
        {
          this.isDuplicated = true;
          this.isError = false;
          this.isCreated = false;
        } else { 
        this.isCreated = false;
        this.isError = true;
        this.isDuplicated = false;
        }
      }
    );
  }

  popToast(message : string) {
    this.toasterService.pop('success', 'DONE', message);
  }
}
