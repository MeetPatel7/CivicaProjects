import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IFootwearDetails } from './ifootwear-details';

@Injectable({
  providedIn: 'root'
})
export class FootwearDetailsService {

  footwearForm : IFootwearDetails = {
    id:0,
    name:'',
    pic:'',
    price:0,
    color:'',
    material:'',
    manufacturingDate: new Date(),
    inStock:true,
    categoryId:0,
    manufacturerId:0
  }

  readonly footwearDetailsUrl = "https://localhost:7235/api/";

  constructor(private httpClient : HttpClient) { }

  getAllFootwear():Observable<IFootwearDetails[]>{
    return this.httpClient.get<IFootwearDetails[]>(this.footwearDetailsUrl +'FootwearDetails');
  }

  getFootwear(categoryId:number):Observable<IFootwearDetails[]>{
    return this.httpClient.get<IFootwearDetails[]>(this.footwearDetailsUrl + 'Categories/' + categoryId +'/FootwearDetails');
  }

  getFootwearDetails(categoryId:number,footwearDetailsId:number):Observable<IFootwearDetails[]>{
    return this.httpClient.get<IFootwearDetails[]>(this.footwearDetailsUrl + 'Categories/' + categoryId +'/FootwearDetails/'+ footwearDetailsId);
  }

  postFootwearDetails(footwearValue:IFootwearDetails[]){
    return this.httpClient.post<IFootwearDetails[]>(this.footwearDetailsUrl + 'FootwearDetails',footwearValue);
  }

  deleteFootwearDetails(footwearDetailsId:number){
    return this.httpClient.delete<IFootwearDetails[]>(this.footwearDetailsUrl + 'FootwearDetails/' + footwearDetailsId);
  }

  putFootwearDetails(){
    return this.httpClient.put<IFootwearDetails[]>(this.footwearDetailsUrl + 'FootwearDetails/' + this.footwearForm.id,this.footwearForm);
  }
}
