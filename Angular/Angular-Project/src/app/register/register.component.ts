import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { IRegister } from '../iregister';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  registerForm!: FormGroup;
  getItemFromLocalStorage: any;
  users: any;

  constructor(private fb: FormBuilder, private router: Router) { }

  ngOnInit(): void {
    this.registerForm = this.fb.group({
      fullname: ['', [Validators.required]],
      email: ['', [Validators.required, Validators.pattern('[a-z0-9]+@[a-z]+\.[a-z]{2,3}')]],
      password: ['', [Validators.required, Validators.minLength(6)]],
      confirmpassword: ['', [Validators.required]]
    },
      {
        validators: this.mustmatch('password', 'confirmpassword')
      }
    )
  }

  get f() {
    return this.registerForm.controls;
  }

  register(): void {
    //alert("Register successfully");
    var registerInfo: IRegister = {
      'id': Number(new Date()),
      'fullname': this.registerForm.value.fullname,
      'email': this.registerForm.value.email,
      'password': this.registerForm.value.password,
      'confirmpassword': this.registerForm.value.confirmpassword
    };

    this.getItemFromLocalStorage = JSON.parse(localStorage.getItem('registerLocalStorage')!);
    this.users = this.getItemFromLocalStorage ? this.getItemFromLocalStorage : [];
    this.users.push(registerInfo);
    localStorage.setItem("registerLocalStorage", JSON.stringify(this.users));

    this.router.navigate(['/register-successful']);
  }

  mustmatch(password: any, confirmpassword: any) {
    return (formgroup: FormGroup) => {
      const passwordcheck = formgroup.controls[password];
      const confirmpasswordcheck = formgroup.controls[confirmpassword];

      if (confirmpasswordcheck.errors && confirmpasswordcheck.errors['confirmedvalidator']) {
        return;
      }
      if (passwordcheck.value !== confirmpasswordcheck.value) {
        confirmpasswordcheck.setErrors({ confirmedvalidator: true });
      }
      else {
        confirmpasswordcheck.setErrors(null);
      }
    };
  }

}
