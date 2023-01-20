import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-edit-user',
  templateUrl: './edit-user.component.html',
  styleUrls: ['./edit-user.component.scss']
})
export class EditUserComponent implements OnInit {

  id: any;
  user: any;
  edituserForm!: FormGroup;

  constructor(private activatedroute: ActivatedRoute, private fb: FormBuilder, private router: Router) { }

  ngOnInit(): void {

    const registerUserData = localStorage.getItem('registerLocalStorage');
    this.user = registerUserData != null ? JSON.parse(registerUserData) : [];

    this.activatedroute.queryParams.subscribe((params: any) => {
      this.id = params.id;
    });

    const userdata = this.user.filter((users: any) => {
      return this.id == users.id;
    });

    this.edituserForm = this.fb.group({
      fullname: [userdata[0].fullname, [Validators.required]],
      email: [userdata[0].email, [Validators.required]]
    })
  }

  updatedata(): void {

    var edituserInfo = {
      'id': this.id,
      'fullname': this.edituserForm.value.fullname,
      'email': this.edituserForm.value.email
    }

    const registerUserData = localStorage.getItem('registerLocalStorage');
    this.user = registerUserData != null ? JSON.parse(registerUserData) : [];
    this.user.splice(this.user.findIndex((a: any) => a.id == edituserInfo.id), 1);
    this.user.push(edituserInfo);
    localStorage.setItem("registerLocalStorage", JSON.stringify(this.user));

    this.router.navigate(['/users-management'], { queryParams: { id: this.id } });
  }

}
