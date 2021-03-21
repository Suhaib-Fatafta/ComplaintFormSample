import { Component, OnInit } from '@angular/core';
import { UserForm } from '../models/UserForm';
import { ComplaintFormService } from '../services/ComplaintForm.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
    selector: "permission",
    templateUrl: './Complaint.component.html',
    styleUrls: ['./Complaint.component.css']
})

export class ComplaintComponent implements OnInit {

    complaintTitle: any;
    userName: any;
    isRecurring: any;
    complaints: string[] = [];
    complaintDetail: any;
    userForms: UserForm[] = [];
    userId: any;
    userRole: any;
    showTable: boolean = false;
    checkboxes = ['Noisy neighbors', 'No hot water', 'Dirty rooms', 'Bad smells']

    constructor(private _complaintFormService: ComplaintFormService, private route: ActivatedRoute, private _router: Router) { }

    ngOnInit() {
        this.userId = Number(this.route.snapshot.paramMap.get('id'))
        this.userRole = this.route.snapshot.paramMap.get('role')

        this._complaintFormService.checkValidUser(this.userId, this.userRole).subscribe((Data) => {
            if (Data == 0) {
                this._router.navigateByUrl('');
            }
        });

        if (this.userRole != "customer") {
            this._complaintFormService.getAllComplaintForms().subscribe((Data: UserForm[]) => {
                this.userForms = Data;
            });
        }
    }

    isCustomer() {
        if (this.userRole == "customer") {
            return true;
        }
        else {
            return false;
        }
    }

    isRecurringChange(event: any) {
        this.isRecurring = event.target.value
    }

    enterComplaintTitle(event: any) {
        this.complaintTitle = event.target.value
    }

    enterUserName(event: any) {
        this.userName = event.target.value
    }

    selectComplaint(e: any, complaint: string) {
        if (e.target.checked) {
            this.complaints.push(complaint);
        }
        else {
            this.complaints.splice(this.complaints.indexOf(complaint), 1)
        }
    }

    enterComplaintDetail(event: any) {
        this.complaintDetail = event.target.value
    }

    submit() {
        const userForm: UserForm = new UserForm();
        userForm.UserName = this.userName;
        userForm.ComplaintDetails = this.complaintDetail;
        userForm.ComplaintTitle = this.complaintTitle;
        userForm.IsRecurring = this.isRecurring;
        userForm.UserId = this.userId;
        userForm.Complaints = this.complaints;
        this._complaintFormService.postComplaintForm(userForm).subscribe();
    }

    showPreviousComplaints() {
        this._complaintFormService.getByUserId(this.userId).subscribe((Data: UserForm[]) => {
            this.userForms = Data;
            this.showTable = true;
        });
    }

    onStatusChange(event: any, formId: any) {
        this._complaintFormService.changeComplaintFormStatus(Number(event.target.value), formId).subscribe();
    }
}