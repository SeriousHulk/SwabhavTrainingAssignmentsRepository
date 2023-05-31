import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http'; 
import { AppComponent } from './app.component';
import { DashboardComponent } from './component/dashboard/dashboard.component';
import { AddContactComponent } from './component/add-contact/add-contact.component';
import { AppRoutingModule } from './app-routing/app-routing.module';
import { NgToastModule } from 'ng-angular-popup';
import { ShowContactsComponent } from './component/show-contacts/show-contacts.component';
import { ReactiveFormsModule } from '@angular/forms';
import { DeleteContectComponent } from './component/delete-contect/delete-contect.component';
import { ContactByIdComponent } from './component/contact-by-id/contact-by-id.component';
import { EditContactComponent } from './component/edit-contact/edit-contact.component';

@NgModule({
  declarations: [
    AppComponent,
    DashboardComponent,
    AddContactComponent,
    ShowContactsComponent,
    DeleteContectComponent,
    ContactByIdComponent,
    EditContactComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    NgToastModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
