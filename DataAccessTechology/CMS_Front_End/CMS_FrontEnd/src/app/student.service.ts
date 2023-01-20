import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IStudent } from './istudent';

@Injectable({
  providedIn: 'root'
})
export class StudentService {

  studentForm : IStudent = {
    id:0,
    firstName:'',
    lastName:'',
    email:'',
    dateOfBirth:new Date()
  }

  readonly studentUrl = "https://localhost:7273/api/v1/Student";

  constructor(private httpClient : HttpClient) { }

  getStudent(): Observable<IStudent[]>{
    return this.httpClient.get<IStudent[]>(this.studentUrl);
  }

  getStudentDetail(id:number):Observable<IStudent[]>{
    return this.httpClient.get<IStudent[]>(this.studentUrl+'/' + id );
  }

  postStudent(studentData:IStudent[]){
    return this.httpClient.post<IStudent[]>(this.studentUrl,studentData);
  }

}
