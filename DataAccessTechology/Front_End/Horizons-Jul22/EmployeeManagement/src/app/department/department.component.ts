import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { DepartmentData } from '../department-data.model';
import { EmployeeServiceService } from '../employee-service.service';

@Component({
  selector: 'app-department',
  templateUrl: './department.component.html',
  styleUrls: ['./department.component.css']
})
export class DepartmentComponent implements OnInit {

  deptData:DepartmentData[]|undefined;

  constructor(public service: EmployeeServiceService) { }

  ngOnInit(): void {
    this.service.refresh();
    this.resetForm1();
  }

  fillForm1(selectedRecord: any) {
    this.service.formData1 = Object.assign({}, selectedRecord);
  }

  onDelete1(DMId: any) {
    if (confirm('Are you sure to delete this record ?')) {
      this.service.deleteDepartment(DMId)
        .subscribe(res => {
          this.service.refresh();
        },
        err => { console.log(err); })
    }
  }
 
  resetForm1(form?: NgForm) {
    if (form != null)
      form.form.reset();
    this.service.formData1 = { 

      DMId: 0,   
      id: 0,  
      name: ' ',
      isActive: 'true'  
    }
  }

}
