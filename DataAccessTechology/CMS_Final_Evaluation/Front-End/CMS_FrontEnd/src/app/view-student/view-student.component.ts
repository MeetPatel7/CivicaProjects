import { Component, OnInit } from '@angular/core';
import { IStudent } from '../istudent';
import { StudentService } from '../student.service';

@Component({
  selector: 'app-view-student',
  templateUrl: './view-student.component.html',
  styleUrls: ['./view-student.component.css']
})
export class ViewStudentComponent implements OnInit {

  studentData !: IStudent[];

  constructor(private studentService:StudentService) { }

  ngOnInit(): void {
    this.viewStudent();
  }

  viewStudent(){
    this.studentService.getStudent().subscribe(
      data => {
        this.studentData = data;
        console.log(this.studentData);
      }
    )
  }
}
