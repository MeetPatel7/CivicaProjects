import { Component, OnInit } from '@angular/core';
import {FormGroup,FormControl} from '@angular/forms';

@Component({
  selector: 'app-binding',
  templateUrl: './binding.component.html',
  styleUrls: ['./binding.component.css']
})
export class BindingComponent implements OnInit {

  formData! : FormGroup;

  constructor() { }

  ngOnInit(): void {
    this.formData = new FormGroup(
      {
        "FirstName": new FormControl(""),
        "LastName": new FormControl("m@p.com"),
        "Email": new FormControl(""),
      }
    );
  }

  onFormSumbit()
  {
    console.log('in submit method');
    console.log(this.formData.value);
  }
}
