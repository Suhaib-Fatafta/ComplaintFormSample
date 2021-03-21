import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ComplaintComponent } from './ComplaintForm/Complaint.component';
import { LoginComponent } from './Login/Login.component'

const routes: Routes = [
  {path:'', component:LoginComponent},
  {path:'Complaint/:id/:role', component:ComplaintComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
