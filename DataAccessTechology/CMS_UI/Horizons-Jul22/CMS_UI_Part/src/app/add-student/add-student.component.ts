import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { StudentService } from '../student.service';

@Component({
  selector: 'app-add-student',
  templateUrl: './add-student.component.html',
  styleUrls: ['./add-student.component.css']
})
export class AddStudentComponent implements OnInit {

  constructor(public studentService:StudentService) { }

  ngOnInit(): void {
  }

  insertStudent(studentForm:NgForm)
  {
    this.studentService.postStudent(studentForm.value).subscribe(
      data => {
        this.studentService.studentForm;
        alert("Record Inserted");
      }
    )
  }

}
