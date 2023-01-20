import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IEnrollment } from './ienrollment';
import { IStudent } from './istudent';

@Injectable({
  providedIn: 'root'
})
export class EnrollmentService {
  readonly enrollmentUrl = "https://localhost:7273/api/v1/Enrollment/";

  enrollmentForm: IEnrollment = {
    id: 0,
    studentId: 0,
    courseId: 0
    //enrollmentDate: new Date()
  }

  constructor(private httpClient: HttpClient) { }

  getEnrollment(): Observable<IEnrollment[]> {
    return this.httpClient.get<IEnrollment[]>(this.enrollmentUrl);
  }

  getStudentCourseCount(id: any): Observable<any> {
    return this.httpClient.get<any>(this.enrollmentUrl + id + '/CourseCount');
  }

  postEnrollment(enrollmentData:IEnrollment[]){
    return this.httpClient.post<IEnrollment[]>(this.enrollmentUrl,enrollmentData)
  }
}
