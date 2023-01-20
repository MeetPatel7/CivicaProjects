import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IStudent } from '../istudent';
import { StudentService } from '../student.service';

@Component({
  selector: 'app-view-student-details',
  templateUrl: './view-student-details.component.html',
  styleUrls: ['./view-student-details.component.css']
})
export class ViewStudentDetailsComponent implements OnInit {

  studentId : any;
  studentDetail : any;

  constructor(public studentService:StudentService, private route:ActivatedRoute) { }

  ngOnInit(): void {
    this.studentId = Number(this.route.snapshot.paramMap.get("id"));
    this.viewStudentDetails();
  }

  viewStudentDetails(){
    this.studentService.getStudentDetail(this.studentId).subscribe(
      data => {
        this.studentDetail = data;
        console.log(this.studentDetail);
      }
    )
  }

}
