import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http'; 
import { Contact } from '../model/contact.model';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private baseUrlContact:string="http://localhost:12906/api/v1/Contacts/";

  constructor(private http:HttpClient) { }

  getContacts(){
    return this.http.get<any>(this.baseUrlContact+"GetAllContacts");
  }
  getContactById(id:string){
    return this.http.get<Contact>(this.baseUrlContact+"GetContactById/"+id);
  }
  updateContact(id:string,updateContactRequest:Contact){
    return this.http.put<Contact>(this.baseUrlContact+"UpdateContact/"+id,updateContactRequest);
  }
  deleteContact(id:string){
    return this.http.delete<Contact>(this.baseUrlContact+'DeleteContact/'+id);
  }
  addContact(addContactRequest:Contact){
      return this.http.post<Contact>(this.baseUrlContact+'AddContact',addContactRequest)
  }
}
