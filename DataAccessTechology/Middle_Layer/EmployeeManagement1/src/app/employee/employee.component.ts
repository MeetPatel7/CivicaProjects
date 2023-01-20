import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { EmployeeServiceService } from '../employee-service.service';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {

  constructor(public service: EmployeeServiceService) { }

  ngOnInit(): void {
    this.service.refreshList();
    this.resetForm();
  }

  fillForm(selectedRecord: any) {
    this.service.formData = Object.assign({}, selectedRecord);
  }

  onDelete(id: any) {
    if (confirm('Are you sure to delete this record ?')) {
      this.service.deleteEmployee(id)
        .subscribe(res => {
          this.service.refreshList();
        },
        err => { console.log(err); })
    }
  }


  resetForm(form?: NgForm) {
    if (form != null)
      form.form.reset();
    this.service.formData = {
    
    id: 0,  
    firstName: '',
    lastName: '',
    email: '',
    dateOfBirth: new Date,
    age: 0,
    joinedDate: new Date,
    isActive: true,
    departmentId: 0,
    EMId: 0
    }
  }

  onSubmit(form: NgForm) {
    if (this.service.formData.EMId == 0)
      this.insertEmployee(form);
    else
      this.updateEmployee(form);
  }

  insertEmployee(form: NgForm) {
    this.service.postEmployee().subscribe(
      res => {
        ;
        this.resetForm(form);
        this.service.refreshList();
      },
      err => {
        console.log(err);
      }
    )
  }

  updateEmployee(form: NgForm) {
    const data={
    
    id: 0,  
    firstName: '',
    lastName: '',
    email: '',
    dateOfBirth: new Date,
    age: 0,
    joinedDate: new Date,
    isActive: true,
    departmentId: 0,
    EMId: 0
      
    }
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
