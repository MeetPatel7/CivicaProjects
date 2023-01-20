import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-login-successful',
  templateUrl: './login-successful.component.html',
  styleUrls: ['./login-successful.component.scss']
})
export class LoginSuccessfulComponent implements OnInit {
  id: any;
  user: any;
  useremail: any;

  constructor(private activatedroute: ActivatedRoute) { }

  ngOnInit(): void {
    this.activatedroute.queryParams.subscribe((param: any) => {
      this.id = param.data;
    })

    const registerdata = localStorage.getItem('registerLocalStorage');
    this.user = registerdata != null ? JSON.parse(registerdata) : [];

    const userdata = this.user.filter((users: any) => {
      return this.id == users.id;
    });

    this.useremail = userdata[0].email;
  }

}
