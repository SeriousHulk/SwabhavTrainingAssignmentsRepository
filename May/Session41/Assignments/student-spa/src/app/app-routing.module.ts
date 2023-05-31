import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DisplayStudentComponent } from './component/display-student/display-student.component';
import { StudentComponent } from './component/student/student.component';
import { WelcomeComponent } from './component/welcome/welcome.component';

const routes: Routes = [
  { path: '', component: WelcomeComponent  },
  { path: 'students', component: DisplayStudentComponent },
  { path: 'add-student', component: StudentComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
