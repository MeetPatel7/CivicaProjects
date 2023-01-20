import { Component, OnInit } from '@angular/core';
import { Form, NgForm } from '@angular/forms';
import { CourseService } from '../course.service';
import { EnrollmentService } from '../enrollment.service';
import { ICourse } from '../icourse';
import { IStudent } from '../istudent';
import { StudentService } from '../student.service';

@Component({
  selector: 'app-add-enrollment',
  templateUrl: './add-enrollment.component.html',
  styleUrls: ['./add-enrollment.component.css']
})
export class AddEnrollmentComponent implements OnInit {

  studentData !: IStudent[];
  courseData !: ICourse[];

  constructor(public enrollmentService:EnrollmentService,public studentService:StudentService,public courseService:CourseService) { }

  ngOnInit(): void {
    this.viewStudent();
    this.viewCourse();
  }

  insertEnrollment(enrollmentForm:NgForm)
  {
    console.log(enrollmentForm.value);
    this.enrollmentService.postEnrollment(enrollmentForm.value).subscribe(
      data => {
        alert("record inserted");
        this.ngOnInit();
      }
    )
  }

  viewStudent()
  {
    this.studentService.getStudent().subscribe(
      data => {
        this.studentData = data;
      }
    )
  }

  viewCourse()
  {
    this.courseService.getCourse().subscribe(
      data => {
        this.courseData = data;
      }
    )
  }
}
