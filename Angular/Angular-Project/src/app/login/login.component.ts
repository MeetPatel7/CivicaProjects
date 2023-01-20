import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  user: any;
  loginForm!: FormGroup;

  constructor(private fb: FormBuilder, private router: Router, private activatedrotue: ActivatedRoute) { }

  ngOnInit(): void {
    this.loginForm = this.fb.group({
      email: ['', [Validators.required]],
      password: ['', [Validators.required]]
    })
  }

  login(): void {

    const loginemail = this.loginForm.value.email;
    const loginpassword = this.loginForm.value.password;

    const registerdata = localStorage.getItem('registerLocalStorage');
    this.user = registerdata != null ? JSON.parse(registerdata) : [];

    const validuser = this.user.filter((register: any) => {
      return loginemail === register.email && loginpassword === register.password;
    });

    const id=validuser[0].id;
    
    if (validuser.length) {
      this.router.navigate(['/login-successful'],{queryParams:{data:id}});
    }
    else {
      alert("Invalid email or password");
    }
  }

}
