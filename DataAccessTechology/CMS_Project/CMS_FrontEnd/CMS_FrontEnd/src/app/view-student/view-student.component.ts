import { Component, OnInit } from '@angular/core';
import { EnrollmentService } from '../enrollment.service';
import { IStudent } from '../istudent';
import { StudentService } from '../student.service';

@Component({
  selector: 'app-view-student',
  templateUrl: './view-student.component.html',
  styleUrls: ['./view-student.component.css']
})
export class ViewStudentComponent implements OnInit {


  studentData !: IStudent[];
  //courseCount !: { courseCounts: any };
  courseCount !: number;
  courseCounts !: number;
  

  constructor(private studentService: StudentService, private enrollmentService: EnrollmentService) { }

  ngOnInit(): void {
    this.viewStudent();
    //this.viewStudentCourseCount(1);
  }

  viewStudent() {
    this.studentService.getStudent().subscribe(
      data => {
        this.studentData = data;
        // console.log(this.studentData);
        for (var i = 0; i < this.studentData.length; i++) {
          // console.log(this.studentData[i]);
          console.log(this.viewStudentCourseCount(this.studentData[i].id));
          // console.log(this.studentData[i].id);
        }
        // this.viewStudentCourseCount(this.studentData);
      }
    )
  }

  //this.studentData.id;

  viewStudentCourseCount(id: any) {
    this.enrollmentService.getStudentCourseCount(id).subscribe(
      data => {
        this.courseCount = data;
        //console.log(this.courseCount);
      }
    )
  }

  deleteStudent(id: number) {
    this.studentService.deleteStudent(id).subscribe(
      data => {
        alert("record has been deleted"),
          (error: any) => {
            alert(error.error.message);
          }
        this.ngOnInit();
      }
    )
  }
}
