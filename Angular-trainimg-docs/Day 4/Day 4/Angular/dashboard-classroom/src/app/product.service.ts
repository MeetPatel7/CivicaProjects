import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  private productUrl = "assets/api/products.json";

  constructor(private HttpServ: HttpClient) { }

  getProducts(): Observable<any> {
    return this.HttpServ.get(this.productUrl); // GET API CALL, Observable
  }

  getUsers() {

  }
}
