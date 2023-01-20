import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  usersApiUrl: string = "https://jsonplaceholder.typicode.com/users";

  constructor(private httpServ: HttpClient) { }

  getUsers() {
    return this.httpServ.get(this.usersApiUrl);
  }
}
