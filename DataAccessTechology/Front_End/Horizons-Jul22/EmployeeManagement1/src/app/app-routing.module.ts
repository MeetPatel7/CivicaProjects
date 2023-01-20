import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { EmployeeFormComponent } from './employee-form/employee-form.component';
import { DepartmentComponent } from './department/department.component';
import { EmployeeComponent } from './employee/employee.component';

const routes: Routes = [
  { path: '', component: EmployeeFormComponent },
  { path: 'EmployeeForm', component: EmployeeFormComponent },
  { path: 'ViewDepartment', component: DepartmentComponent },
  { path: 'ViewEmployee', component: EmployeeComponent }
];

@NgModule({
  declarations: [],
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
