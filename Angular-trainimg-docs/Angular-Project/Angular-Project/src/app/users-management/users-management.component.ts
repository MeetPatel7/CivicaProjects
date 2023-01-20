import { Component, OnInit, ɵɵngDeclareInjectable } from '@angular/core';

@Component({
  selector: 'app-users-management',
  templateUrl: './users-management.component.html',
  styleUrls: ['./users-management.component.scss']
})
export class UsersManagementComponent implements OnInit {

  user:any;
  constructor() { } 

  ngOnInit(): void {
    this.user=[
      {
        username:'Harsh Darji',
        emailid:'hd@gmail.com'
      },
      {
        username:'Khushal Rana',
        emailid:'rk@gmail.com' 
      },
      {
        username:'Hard Parikh',
        emailid:'hp@gmail.com' 
      },
      {
        username:'Avsar Savaliya',
        emailid:'as@gmail.com' 
      }
    ]
  }
}
