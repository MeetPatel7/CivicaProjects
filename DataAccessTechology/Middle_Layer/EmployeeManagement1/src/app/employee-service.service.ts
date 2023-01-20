import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { DepartmentData } from './department-data.model';
import { EmployeeData } from './employee-data.model';

@Injectable({
  providedIn: 'root'
})
export class EmployeeServiceService {
  formData: EmployeeData = new EmployeeData()
  formData1: DepartmentData = new DepartmentData()
  readonly EmployeeURL = "https://localhost:7079/api/v1/Employee";
  readonly DepartmentURL = "https://localhost:7079/api/v1/Department";

  Employeelist: EmployeeData[] | undefined;
  Departmentlist: DepartmentData[] | undefined;
  constructor(public http: HttpClient) { }

  putEmployee() {
    return this.http.put(`${this.EmployeeURL}/${this.formData.id}`, this.formData);
  }
  postEmployee() {
    return this.http.post(this.EmployeeURL, this.formData);
  }
  deleteEmployee(id: number) {
    return this.http.delete(`${this.EmployeeURL}/${id}`);
  }

  refreshList() {
    this.http.get(this.EmployeeURL)
      .toPromise()
      .then(res => this.Employeelist = res as EmployeeData[]);
  }

  deleteDepartment(id: number) {
    return this.http.delete(`${this.DepartmentURL}/${id}`);
  }

  refresh() {
    this.http.get(this.DepartmentURL)
      .toPromise()
      .then(res => this.Departmentlist = res as DepartmentData[]);
  }
}
