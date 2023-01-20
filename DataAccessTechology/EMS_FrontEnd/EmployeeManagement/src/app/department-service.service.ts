import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { DepartmentData } from './department-data.model';

@Injectable({
  providedIn: 'root'
})
export class DepartmentServiceService {

  formData: DepartmentData = new DepartmentData()
  readonly DepartmentURL = "https://localhost:7079/api/v1/Department";

  Departmentlist!: DepartmentData[];

  constructor(private http : HttpClient) { }

  deleteDepartment(id: number) {
    return this.http.delete(`${this.DepartmentURL}/${id}`);
  }

  // refresh() {
  //   this.http.get(this.DepartmentURL)
  //     .toPromise()
  //     .then(res => this.Departmentlist = res as DepartmentData[]);
  // }

  getDepartment():Observable<DepartmentData[]>{
    return this.http.get<DepartmentData[]>(this.DepartmentURL);
  }
}
