import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UserForm } from '../models/UserForm';
import { ComplaintApiConfiguration } from './app.constant.service';

@Injectable()

export class ComplaintFormService {

    private _actionUrl: string
    private _getUserFormByUserId: string;
    private _getAllUserForm: string;
    private _changeComplaintStatus: string;
    private _url: string
    private _validUser: string

    constructor(private _http: HttpClient, private _configuration: ComplaintApiConfiguration) {
        this._actionUrl = _configuration.server;
        this._getUserFormByUserId = this._actionUrl + _configuration.complaintForm.GetUserFormByUserId;
        this._getAllUserForm = this._actionUrl + _configuration.complaintForm.GetAllUserForm;
        this._changeComplaintStatus = this._actionUrl + _configuration.complaintForm.ChangeComplaintStatus;
        this._url = this._actionUrl + _configuration.complaintForm.url;
        this._validUser = this._actionUrl + _configuration.complaintForm.ValidUser;
    }

    postComplaintForm = (userForm: UserForm): Observable<any> => {
        const url = `${this._url}`
        return this._http.post<any>(url, userForm);
    }

    getByUserId = (userId: number): Observable<any> => {
        const url = `${this._getUserFormByUserId}?userId=${userId}`;
        return this._http.get<any>(url);

    }

    getAllComplaintForms = (): Observable<any> => {
        const url = `${this._getAllUserForm}`;
        return this._http.get<any>(url);
    }

    changeComplaintFormStatus = (statusId: number, formId: string): Observable<any> => {
        const url = `${this._changeComplaintStatus}?statusId=${statusId}&&formId=${formId}`
        return this._http.put<any>(url, null);
    }

    userLogin = (userName: string, password: string): Observable<any> => {
        const url = `${this._url}?userName=${userName}&&password=${password}`;
        return this._http.get<any>(url);
    }

    checkValidUser = (userId: number, role: string): Observable<any> => {
        const url = `${this._validUser}?userId=${userId}&&role=${role}`;
        return this._http.get<any>(url);
    }
}