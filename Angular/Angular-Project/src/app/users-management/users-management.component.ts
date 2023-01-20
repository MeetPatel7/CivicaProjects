import { Component, OnInit, ɵɵngDeclareInjectable } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-users-management',
  templateUrl: './users-management.component.html',
  styleUrls: ['./users-management.component.scss']
})
export class UsersManagementComponent implements OnInit {

  id: any;
  user: any;
  constructor(private activatedroute: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {

    this.activatedroute.queryParams.subscribe((params: any) => {
      this.id = params.id;
    });
    const registerUserData = localStorage.getItem('registerLocalStorage');
    this.user = registerUserData != null ? JSON.parse(registerUserData) : [];
  }

  deleteuser(): void {

    let deleteuserid: any = null;
    this.activatedroute.queryParams.subscribe((params: any) => {
      deleteuserid = params.id;
    });

    const registerUserData = localStorage.getItem('registerLocalStorage');
    this.user = registerUserData != null ? JSON.parse(registerUserData) : [];
    this.user.splice(this.user.findIndex((a: any) => a.id == deleteuserid), 1);
    localStorage.setItem("registerLocalStorage", JSON.stringify(this.user));
    this.ngOnInit();
  }
}
