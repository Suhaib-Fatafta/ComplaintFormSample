import { Injectable } from "@angular/core"

@Injectable()
export class ComplaintApiConfiguration {
    server = 'http://localhost:61709/api/'

    complaintForm = {
        url: 'ComplaintForm',
        GetUserFormByUserId: 'ComplaintForm/GetUserFormByUserId',
        GetAllUserForm: 'ComplaintForm/GetAllUserForm',
        ChangeComplaintStatus: 'ComplaintForm/ChangeComplaintStatus',
        ValidUser: 'ComplaintForm/ValidUser'
    }
}