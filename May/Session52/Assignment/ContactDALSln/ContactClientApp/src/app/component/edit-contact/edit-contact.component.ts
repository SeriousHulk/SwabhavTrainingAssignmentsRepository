import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Contact } from 'src/app/model/contact.model';
import { ApiService } from 'src/app/services/api.service';
import ValidateForm from 'src/app/validation/validateFrom';

@Component({
  selector: 'app-edit-contact',
  templateUrl: './edit-contact.component.html',
  styleUrls: ['./edit-contact.component.css']
})
export class EditContactComponent implements OnInit {
  updateForm: FormGroup;  
  contactDetails: Contact = {
    Id: 0,
    Name: '',
    MobileNumber: '',
    Address: ''
  };

  constructor(
    private route: ActivatedRoute,
    private api: ApiService,
    private router: Router,
    private fb: FormBuilder
  ) {}

  ngOnInit(): void {
    this.updateForm = this.fb.group({
      Name: ['', Validators.required],
      MobileNumber: ['', Validators.required]
    });

    this.route.paramMap.subscribe({
      next: (params) => {
        const id = params.get('id');
        if (id) {
          this.api.getContactById(id).subscribe({
            next: (response) => {
              this.contactDetails = response;
              this.updateForm.patchValue(this.contactDetails);
            }
          });
        }
      }
    });
  }

  onUpdate() {
    console.log(this.contactDetails);
    if (this.updateForm.valid) {
      this.updateForm.value.Id = Number(this.updateForm.value.Id);
      this.api.updateContact(this.contactDetails.Id.toString(), this.updateForm.value).subscribe({
        next: (res) => {
          alert('SUCCESS: Contact Updated Successfully!!');
          this.router.navigate(['']);
        },
        error: (err) => {
          alert('ERROR: ' + err?.error.message);
        }
      });
    } else {
      // logic for throwing Error if Form is Not Valid
      ValidateForm.validateAllFormFields(this.updateForm);
    }
  }
}
