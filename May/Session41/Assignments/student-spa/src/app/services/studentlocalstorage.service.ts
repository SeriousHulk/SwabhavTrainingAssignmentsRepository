import { HttpClient } from '@angular/common/http';
import { EventEmitter, Injectable } from '@angular/core';
import { Observable, map, of, take } from 'rxjs';
import { Student } from './student.model';

@Injectable({
  providedIn: 'root'
})
export class StudentlocalstorageService {
  private readonly KEY = 'students';
  studentAdded = new EventEmitter<void>();

  constructor() {}

  addStudent(student: Student): Observable<void> {
    return this.getStudents().pipe(
      take(1),
      map((students) => {
        students.push(student);
        localStorage.setItem(this.KEY, JSON.stringify(students));
        this.studentAdded.emit();
      })
    );
  }

  getStudents(): Observable<Student[]> {
    const students = JSON.parse(localStorage.getItem(this.KEY)!);
    return of(students || []);
  }
}
