import { NgModule } from '@angular/core';
import {RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from '../component/dashboard/dashboard.component';
import { AddContactComponent } from '../component/add-contact/add-contact.component';
import { ShowContactsComponent } from '../component/show-contacts/show-contacts.component';
import { DeleteContectComponent } from '../component/delete-contect/delete-contect.component';
import { ContactByIdComponent } from '../component/contact-by-id/contact-by-id.component';
import { EditContactComponent } from '../component/edit-contact/edit-contact.component';


const routes:Routes=[
  {path:'',component:DashboardComponent},
  {path:"AddContact",component:AddContactComponent},
  {path:"ShowContacts",component:ShowContactsComponent},
  {path:"EditContact/:id",component:EditContactComponent},
  {path:"DeleteContact/:id",component:DeleteContectComponent},
  {path:"ContactById/:id",component:ContactByIdComponent}
]

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports:[RouterModule]
})
export class AppRoutingModule { }
