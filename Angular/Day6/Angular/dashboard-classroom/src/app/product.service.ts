import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map, Observable } from 'rxjs';
import { Iproduct } from './iproduct';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  private productUrl = "assets/api/products.json";

  constructor(private HttpServ: HttpClient) { }

  getProducts(): Observable<any> {
    return this.HttpServ.get(this.productUrl); // GET API CALL, Observable
  }

  getProduct(id: number): Observable<Iproduct | undefined> {
    return this.getProducts().pipe(
      map((products: Iproduct[]) => products.find(p => p.productId === id))
    )
  }

  getUsers() {

  }
}
