import { Component, OnInit } from '@angular/core';
import { DataSharingService } from '../data-sharing.service';

import { CookieService } from 'ngx-cookie-service';
import { User } from '../models/user';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {
  cookieValue = 'UNKNOWN';
  user:User = new User();
  show:boolean = true;
  state:string = '';
  log:boolean = false;
  text:string ='';

  constructor(private _shared: DataSharingService, private cookieService: CookieService) {
    this.user.Name="";
    this.user.LastName="";
  }

  ngOnInit() {
    this.user.LastName = this.cookieService.get('Lname');
    this.user.Name = this.cookieService.get('Name');
    if(this.cookieService.get('User')!=''){
      this.state = '#';
      this.text = 'Log out';
      this.show = false;
      this.log = true;
    }else{
      this.text = 'Log in';
      this.state ='/log-in';
      this.show = true;
      this.log = false;
    }
  }

  logout(){
    this.cookieService.set('User','');
    this.cookieService.set('Name','');
    this.cookieService.set('Lname','');
  }

}
