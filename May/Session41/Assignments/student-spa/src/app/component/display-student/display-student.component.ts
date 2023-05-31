import { Component, OnInit } from '@angular/core';
import { Student } from 'src/app/services/student.model';
import { StudentlocalstorageService } from 'src/app/services/studentlocalstorage.service';

@Component({
  selector: 'app-display-student',
  templateUrl: './display-student.component.html',
  styleUrls: ['./display-student.component.css']
})
export class DisplayStudentComponent implements OnInit{
  students: Student[]=[];

  constructor(private studentLocalStorageService: StudentlocalstorageService) { }
  ngOnInit(): void {
    this.getStudents();
    this.studentLocalStorageService.studentAdded.subscribe(() => {
      this.getStudents();
    });
  }

  getStudents(): void {
    this.studentLocalStorageService.getStudents().subscribe((students) => {
      this.students = students;
    });
  }

  RemoveStudent(){
    
  }
}
