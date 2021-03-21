import { Component, OnInit } from '@angular/core';
import { ComplaintFormService } from '../services/ComplaintForm.service';
import { Router } from '@angular/router';
import jwt_decode from "jwt-decode";

@Component({
    selector: "Login",
    templateUrl: './Login.component.html',
    styleUrls: ['./Login.component.css']
})

export class LoginComponent implements OnInit {

    userName: any
    password: any

    constructor(private _complaintFormService: ComplaintFormService, private _router: Router) { }

    ngOnInit() { }

    enterUserName(event: any) {
        this.userName = event.target.value
    }

    enterPassword(event: any) {
        this.password = event.target.value
    }

    login() {
        this._complaintFormService.userLogin(this.userName, this.password).subscribe(token => {
            if (token != null) {
                var decoded = jwt_decode(token) as any;
                this._router.navigateByUrl('Complaint/' + decoded.id + '/' + decoded.role);
            }
        })
    }
}