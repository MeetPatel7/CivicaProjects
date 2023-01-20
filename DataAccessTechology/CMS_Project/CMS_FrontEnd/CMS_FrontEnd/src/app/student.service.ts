import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IStudent } from './istudent';

@Injectable({
  providedIn: 'root'
})
export class StudentService {

  readonly studentUrl = "https://localhost:7273/api/v1/Student/";

  studentForm: IStudent = {
    id: 0,
    firstName: '',
    lastName: '',
    email: '',
    dateOfBirth: new Date()
  }

  // studentForm: IStudent[] = [];

  constructor(private httpClient: HttpClient) { }

  getStudent(): Observable<IStudent[]> {
    return this.httpClient.get<IStudent[]>(this.studentUrl);
  }

  getStudentDetail(id: number): Observable<IStudent[]> {
    return this.httpClient.get<IStudent[]>(this.studentUrl + id);
  }

  postStudent(studentData: IStudent[]) {
    return this.httpClient.post<IStudent[]>(this.studentUrl, studentData);
  }

  deleteStudent(id: number) {
    return this.httpClient.delete(this.studentUrl + id);
  }

}
