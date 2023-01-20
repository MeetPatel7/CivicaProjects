import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ICategories } from './icategories';

@Injectable({
  providedIn: 'root'
})
export class CategoriesService {

  readonly categoriesUrl = "https://localhost:7235/api/Categories";

  constructor(private httpClient : HttpClient) { }

  getCategories(): Observable<ICategories[]>{
    return this.httpClient.get<ICategories[]>(this.categoriesUrl);
  }
}
