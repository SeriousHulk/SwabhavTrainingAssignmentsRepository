import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ApiService } from 'src/app/services/api.service';
import ValidateForm from 'src/app/validation/validateFrom';

@Component({
  selector: 'app-add-contact',
  templateUrl: './add-contact.component.html',
  styleUrls: ['./add-contact.component.css']
})
export class AddContactComponent implements OnInit {
  addForm: FormGroup;

  constructor(
    private api: ApiService,
    private router: Router,
    private fb: FormBuilder
  ) {}

  ngOnInit(): void {
    this.addForm = this.fb.group({
      Name: ['', Validators.required],
      MobileNumber: ['', Validators.required]
    });
  }

  onAdd() { 
    if (this.addForm.valid) { 
      this.addForm.value.Id = Number(this.addForm.value.Id); 
      console.log(this.addForm.value); 
      // Perform Logic for Adding Student 
      this.api.addContact(this.addForm.value).subscribe( 
        () => { 
          window.alert('Contact added successfully!'); 
          this.router.navigate(['']); 
        }, 
        (err) => { 
          console.error(err); 
        } 
      ); 
    } else { 
      // Logic for throwing Error if Form is Not Valid 
      ValidateForm.validateAllFormFields(this.addForm); 
    } 
  }
  // onAdd() {
  //   if (this.addForm.valid) {
  //     this.addForm.value.Id = Number(this.addForm.value.Id);
  //     console.log(this.addForm.value);
  //     // Perform Logic for Adding Contact
  //     this.api.addContact(this.addForm.value).subscribe({
  //       next: (res) => {
  //         alert('SUCCESS: Contact Added Successfully!!');
  //         this.router.navigate(['']);

  //         // Fetch the updated contact list
  //         this.api.getContacts().subscribe((contacts) => {
  //           // Update the table with the new contact
  //           // Update your contact list array or any other data structure used for the table
  //         });
  //       },
  //       error: (err) => {
  //         alert('ERROR: ' + err?.error.message);
  //       }
  //     });
  //   } else {
  //     // Logic for throwing Error if Form is Not Valid
  //     ValidateForm.validateAllFormFields(this.addForm);
  //   }
  // }
}
