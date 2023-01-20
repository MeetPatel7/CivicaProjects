import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { EmployeeData } from '../employee-data.model';
import { EmployeeServiceService } from '../employee-service.service';

@Component({
  selector: 'app-employee-form',
  templateUrl: './employee-form.component.html',
  styleUrls: ['./employee-form.component.css']
})
export class EmployeeFormComponent implements OnInit {
  checked=true;
  bday:any;
  joinDate:any;
  constructor(public service: EmployeeServiceService) {


  }

  ngOnInit(): void {
  }

  resetForm(form: NgForm) {
    form.form.reset();
    this.service.formData = new EmployeeData();
  }

  
  insertRecord(form: NgForm) {
    debugger
    this.service.postEmployee().subscribe(
      res => {
        this.resetForm(form);
        this.service.refreshList();
      },
      err => { console.log(err); }
    )
  }


  onSubmit(form: NgForm) {
   
    if (this.service.formData.EMId == 0)
      this.insertRecord(form);
    else
    this.bday=form.value.dateOfBirth;
    form.value.joinedDate=new Date();
      this.updateRecord(form);
  }
  
  updateRecord(form: NgForm) {
    
    this.service.putEmployee().subscribe(
      res => {
        this.resetForm(form);
        this.service.refreshList();
      },
      err => {
        console.log(err);
      }
    )
  }

}
