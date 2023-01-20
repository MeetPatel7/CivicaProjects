import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Route, Router } from '@angular/router';
import { EmployeeData } from '../employee-data.model';
import { EmployeeServiceService } from '../employee-service.service';

@Component({
  selector: 'app-employee-form',
  templateUrl: './employee-form.component.html',
  styleUrls: ['./employee-form.component.css']
})
export class EmployeeFormComponent implements OnInit {

  addEmployee: EmployeeData = {
    id:0,
    firstName: '',
    lastName: '',
    dateOfBirth : new Date(),
    age: 0,
    email: '',
    isActive:true,
    joinedDate:new Date(),
    departmentId: 0

  }
  constructor(public service: EmployeeServiceService, private route: Router) {
  }

  ngOnInit(): void {
  }

  resetForm(form: NgForm) {
    form.form.reset();
    this.service.employeeFormData = new EmployeeData();
  }

  // onSubmit(form: NgForm) {
  //   if (this.service.employeeFormData.id == 0)
  //     this.insertRecord(form);

  //   else
  //     form.value.dateOfBirth;
  //     form.value.joinedDate=new Date();
  //     this.updateRecord(form);
  // }

  onSubmit() {
    if (this.addEmployee.id == 0)
    {
      console.log(this.addEmployee.id);
      this.insertEmployee();
    }
    // else
    //   form.value.dateOfBirth;
    // form.value.joinedDate = new Date();
    // this.updateRecord(form);
  }

  // insertRecord(form: NgForm) {
  //   //debugger
  //   this.service.postEmployee().subscribe(
  //     res => {
  //       this.resetForm(form);
  //       this.service.refreshList();
  //     },
  //     err => {
  //       console.log(err);
  //     }
  //   )
  // } 

  insertEmployee() {
    //debugger
    console.log(this.addEmployee);
    this.service.postEmployee(this.addEmployee).subscribe({
      next:(employee)=>{
        this.route.navigate(['ViewEmployee']);
      }
    });
  }

  // updateRecord(form: NgForm) {

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

  // updateEmployee(){
  //   this.service.putEmployee(this.addEmployee.id)
  // }
}
