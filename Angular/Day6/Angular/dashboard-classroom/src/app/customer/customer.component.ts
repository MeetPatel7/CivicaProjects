import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.scss']
})
export class CustomerComponent implements OnInit {

  customerForm!: FormGroup; // property form 
  users: any;
  getItemFromLocalStorage: any;

  constructor(private fb: FormBuilder) { }

  ngOnInit(): void { // method
    this.customerForm = this.fb.group({
      firstName: ['', [Validators.required, Validators.minLength(3)]],
      lastName: ['', [Validators.required, Validators.maxLength(50)]]
    })
    console.log(this.customerForm);
  }

  save(): void {
    var userInfo = {
      id: Number(new Date()),
      'firstName': this.customerForm.value.firstName,
      'lastName': this.customerForm.value.lastName,
    };

    this.getItemFromLocalStorage = JSON.parse(localStorage.getItem('customerLocalStorage')!);
    this.users = this.getItemFromLocalStorage ? this.getItemFromLocalStorage : []; // ternary operator
    this.users.push(userInfo);
    localStorage.setItem("customerLocalStorage", JSON.stringify(this.users));
  }

}
