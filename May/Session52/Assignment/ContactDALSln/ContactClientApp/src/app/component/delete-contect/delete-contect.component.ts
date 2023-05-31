import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'app-delete-contect',
  templateUrl: './delete-contect.component.html',
  styleUrls: ['./delete-contect.component.css']
})
export class DeleteContectComponent implements OnInit {
  constructor(
    private route: ActivatedRoute,
    private api: ApiService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.route.paramMap.subscribe({
      next: (params) => {
        const id = params.get('id');
        if (id) {
          this.api.deleteContact(id).subscribe({
            next: (res) => {
              alert('SUCCESS: Contact Deleted Successfully!!');
              this.router.navigate(['']);
            },
            error: (err) => {
              alert('ERROR: ' + err?.error.message);
            }
          });
        }
      }
    });
  }
}