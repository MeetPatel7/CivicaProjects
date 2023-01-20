import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ViewStudentComponent } from './view-student/view-student.component';
import { ViewCourseComponent } from './view-course/view-course.component';
import { ViewCourseDetailsComponent } from './view-course-details/view-course-details.component';
import { ViewStudentDetailsComponent } from './view-student-details/view-student-details.component';
import { AddStudentComponent } from './add-student/add-student.component';
import { AddEnrollmentComponent } from './add-enrollment/add-enrollment.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule }from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    ViewStudentComponent,
    ViewCourseComponent,
    ViewCourseDetailsComponent,
    ViewStudentDetailsComponent,
    AddStudentComponent,
    AddEnrollmentComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
