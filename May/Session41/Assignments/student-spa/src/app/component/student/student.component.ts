import { Component, OnInit, EventEmitter, Output} from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Student } from 'src/app/services/student.model';
import { StudentlocalstorageService } from 'src/app/services/studentlocalstorage.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-student',
  templateUrl: './student.component.html',
  styleUrls: ['./student.component.css']
})
export class StudentComponent implements OnInit{
  studentForm: FormGroup=new FormGroup({});
  students: Student[] =[];

  @Output() studentAdded = new EventEmitter<void>();

  constructor(private fb: FormBuilder, private studentLocalStorageService: StudentlocalstorageService, private router: Router) { }

  ngOnInit(): void {
    this.studentForm = this.fb.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      cgpa: ['', [Validators.required, Validators.min(0), Validators.max(10)]],
    });
    this.onDisplay();
  }
  onSubmit(): void {
    const { firstName, lastName, cgpa } = this.studentForm.value;
    const student: Student = new Student(firstName, lastName, cgpa);
    this.studentLocalStorageService.addStudent(student).subscribe(() => {
      this.studentForm.reset();
      this.studentAdded.emit();
    });
  }
  onDisplay(): void {
    this.studentLocalStorageService.getStudents().subscribe((students) => {
      this.students = students;
    });
  }
  goToDisplayStudents() {
    this.router.navigate(['/students']);
  }
}
