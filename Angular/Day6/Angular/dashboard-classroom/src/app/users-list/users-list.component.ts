import { Component, OnInit } from '@angular/core';
import { UserService } from '../user.service';

@Component({
  selector: 'app-users-list',
  templateUrl: './users-list.component.html',
  styleUrls: ['./users-list.component.scss']
})
export class UsersListComponent implements OnInit {

  users: any;
  constructor(private userServ: UserService) { }

  ngOnInit(): void {
    this.userServ.getUsers().subscribe({
      next: users => {
        this.users = users
      }
    })
  }

}
