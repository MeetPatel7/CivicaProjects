import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { EmployeeData } from '../employee-data.model';
import { EmployeeServiceService } from '../employee-service.service';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {

  employeeData !:  EmployeeData[];

  constructor(public service: EmployeeServiceService) { }

  ngOnInit(): void {
    //this.service.refreshList();
    this.viewEmployee();
    //this.resetForm();
  }

  fillForm(selectedRecord: any) {
    this.service.employeeFormData = Object.assign({}, selectedRecord);
  }

  // resetForm(form?: NgForm) {
  //   if (form != null)
  //     form.form.reset();
  //   this.service.formData = {    
  //   id: 0,  
  //   firstName: '',
  //   lastName: '',
  //   email: '',
  //   dateOfBirth: new Date,
  //   age: 0,
  //   joinedDate: new Date,
  //   isActive: true,
  //   departmentId: 0,
  //   }
  // }

  // updateEmployee(form: NgForm) {
  //   this.service.putEmployee().subscribe(
  //     res => {
  //       this.resetForm(form);
  //       this.service.refreshList();
  //     },
  //     err => {
  //       console.log(err);
  //     }
  //   )
  // }

  viewEmployee(){
    this.service.getEmployee().subscribe(
      data => {
        this.employeeData = data;
      }
    )
  }
}
