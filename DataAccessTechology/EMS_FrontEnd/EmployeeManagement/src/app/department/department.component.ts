import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { DepartmentData } from '../department-data.model';
import { DepartmentServiceService } from '../department-service.service';
//import { EmployeeServiceService } from '../employee-service.service';

@Component({
  selector: 'app-department',
  templateUrl: './department.component.html',
  styleUrls: ['./department.component.css']
})
export class DepartmentComponent implements OnInit {

  deptData!: DepartmentData;
  index!: number;
  departmentData !: DepartmentData[];

  constructor(public service: DepartmentServiceService) { }

  ngOnInit(): void {
    // this.service.refresh();
    // this.resetForm1();
    this.viewDepartment();
  }

  fillForm1(selectedRecord: any) {
    this.service.formData = Object.assign({}, selectedRecord);
  }

  // deleteDep(id: any) {
  //   this.index = this.service.Departmentlist.findIndex(x => x.id == id);

  //   this.deptData = this.service.Departmentlist[this.index];
  //   if (this.deptData.isActive == false) {
  //     if (confirm('Are you sure to delete this record ?')) {
  //       this.service.deleteDepartment(id)
  //         .subscribe(res => {
  //           this.service.refresh();
  //         },
  //           err => { console.log(err); })
  //     }
  //   }
  //   else
  //   {
  //     confirm('This data cannot be delete');
  //   }
  // }

  // resetForm1(form?: NgForm) {
  //   if (form != null)
  //     form.form.reset();
  //   this.service.formData = {
  //     id: 0, name: ' ', isActive: true
  //   }
  // }

  viewDepartment(){
    this.service.getDepartment().subscribe(
      data => {
        this.departmentData = data;
      }
    )
  }
}
