import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { DepartmentData } from './department-data.model';
import { EmployeeData } from './employee-data.model';

@Injectable({
  providedIn: 'root'
})
export class EmployeeServiceService {
  employeeFormData: EmployeeData = new EmployeeData()
  //formData1: DepartmentData = new DepartmentData()
  readonly EmployeeURL = "https://localhost:7079/api/v1/Employee";
  //readonly DepartmentURL = "https://localhost:7079/api/v1/Department";

  Employeelist !: EmployeeData[];
  //Departmentlist!: DepartmentData[];
  constructor(private http: HttpClient) { }

  // putEmployee() {
  //   return this.http.put(`${this.EmployeeURL}/${this.employeeFormData.id}`, this.employeeFormData);
  // }

  putEmployee(id:number,updateEmployee:EmployeeData):Observable<EmployeeData>{
    return this.http.put<EmployeeData>(this.EmployeeURL+'/'+id,this.employeeFormData = updateEmployee);
  }

  // postEmployee() {
  //   //debugger
  //   return this.http.post(this.EmployeeURL, this.formData);
  // }

  postEmployee(addEmployee:EmployeeData): Observable<EmployeeData>{
    //debugger
    return this.http.post<EmployeeData>(this.EmployeeURL,this.employeeFormData = addEmployee);
  }

  refreshList() {
    this.http.get(this.EmployeeURL)
      .toPromise()
      .then(res => this.Employeelist = res as EmployeeData[]);
  }

  getEmployee(): Observable<EmployeeData[]>{
    return this.http.get<EmployeeData[]>(this.EmployeeURL);
  }

  // deleteDepartment(id: number) {
  //   return this.http.delete(`${this.DepartmentURL}/${id}`);
  // }

  // refresh() {
  //   this.http.get(this.DepartmentURL)
  //     .toPromise()
  //     .then(res => this.Departmentlist = res as DepartmentData[]);
  // }
}
