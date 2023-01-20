import { Component, OnInit } from '@angular/core';
import { IUser } from '../iuser';

@Component({
  selector: 'app-users-list',
  templateUrl: './users-list.component.html',
  styleUrls: ['./users-list.component.scss']
})
export class UsersListComponent implements OnInit {

  user: IUser[]=[];
  constructor() { }

  ngOnInit(): void {
    this.user = [
      {
        id: 1,
        fullname: 'Harsh Darji',
        email: 'hd@gmail.com',
        password: 'hd123'
      },
      {
        id: 2,
        fullname: 'Khushal Rana',
        email: 'rk@gmail.com',
        password: 'rk123'
      },
      {
        id: 3,
        fullname: 'Hard Parikh',
        email: 'hp@gmail.com',
        password: 'hp123'
      },
      {
        id: 4,
        fullname: 'Avser Savaliya',
        email: 'as@gmail.com',
        password: 'as123'
      }       
    ]
  }

}
