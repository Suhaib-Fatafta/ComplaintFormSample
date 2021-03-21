import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ComplaintComponent } from './ComplaintForm/Complaint.component';
import { HttpClientModule } from '@angular/common/http';
import {ComplaintFormService} from './services/ComplaintForm.service';
import {ComplaintApiConfiguration} from './services/app.constant.service';
import {LoginComponent} from './Login/Login.component';


@NgModule({
  declarations: [
    AppComponent,
    ComplaintComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    
  ],
  providers: [ComplaintFormService,ComplaintApiConfiguration],
  bootstrap: [AppComponent]
})
export class AppModule { }
