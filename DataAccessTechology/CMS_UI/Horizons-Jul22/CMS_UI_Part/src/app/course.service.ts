import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ICourse } from './icourse';

@Injectable({
  providedIn: 'root'
})
export class CourseService {

  readonly courseUrl = "https://localhost:7273/api/v1/Course/";

  constructor(private httpClient : HttpClient) { }

  getCourse(): Observable<ICourse[]>{
    return this.httpClient.get<ICourse[]>(this.courseUrl);
  }

  getCourseDetail(id:number):Observable<ICourse[]>{
    return this.httpClient.get<ICourse[]>(this.courseUrl + id );
  }
}
