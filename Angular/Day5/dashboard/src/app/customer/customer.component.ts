import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.scss']
})
export class CustomerComponent implements OnInit {

  customerForm!:FormGroup;

  constructor(private fb:FormBuilder) { }

  ngOnInit(): void {
      this.customerForm=this.fb.group({
        firstname:['',[Validators.required,Validators.minLength(5)]],
        lastname:['',[Validators.required,Validators.maxLength(25)]]
      })
  }

}
