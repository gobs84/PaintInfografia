import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule, RoutingComponents } from './app-routing.module';

import { AppComponent } from './app.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { HttpService } from './http.service';
import { AuthGuard } from './auth.guard';

import { CookieService } from 'ngx-cookie-service';
import {ToasterModule} from 'angular2-toaster';

@NgModule({
  declarations: [
    AppComponent,
    NavBarComponent,
    RoutingComponents,

  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    AppRoutingModule,
    ReactiveFormsModule,
    ToasterModule.forRoot()
  ],
  providers: [HttpService,AuthGuard,CookieService],
  bootstrap: [AppComponent]
})
export class AppModule { }
