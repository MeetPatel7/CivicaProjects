import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddStudentComponent } from './add-student/add-student.component';
import { ViewCourseDetailsComponent } from './view-course-details/view-course-details.component';
import { ViewCourseComponent } from './view-course/view-course.component';
import { ViewStudentDetailsComponent } from './view-student-details/view-student-details.component';
import { ViewStudentComponent } from './view-student/view-student.component';

const routes: Routes = [
  {
    path : '', component:AddStudentComponent
  },
  {
    path : 'AddStudent', component:AddStudentComponent
  },
  {
    path : 'ViewStudent', component:ViewStudentComponent
  },
  {
    path : 'ViewStudent/:id', component:ViewStudentDetailsComponent
  },
  {
    path : 'ViewCourse', component:ViewCourseComponent
  },
  {
    path : 'AddStudent/ViewCourse', component:ViewCourseComponent
  },
  {
    path : 'ViewCourse/:id', component:ViewCourseDetailsComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
