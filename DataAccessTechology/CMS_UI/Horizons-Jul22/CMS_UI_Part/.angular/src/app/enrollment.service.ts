import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IEnrollment } from './ienrollment';

@Injectable({
  providedIn: 'root'
})
export class EnrollmentService {
  readonly studentUrl = "https://localhost:7273/api/v1/Enrollment/";

  constructor(private httpClient : HttpClient) { }

  getEnrollment(): Observable<IEnrollment[]>{
    return this.httpClient.get<IEnrollment[]>(this.studentUrl);
  }
}
