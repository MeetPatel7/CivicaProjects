import { ComponentFixture, TestBed } from '@angular/core/testing';
import { Component, OnInit } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { EmployeeServiceService } from '../employee-service.service';
import { EmployeeComponent } from './employee.component';
import { HttpClientTestingModule} from '@angular/common/http/testing';

describe('EmployeeComponent', () => {
  let component: EmployeeComponent;
  let fixture: ComponentFixture<EmployeeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EmployeeComponent ],
      imports:[HttpClientTestingModule,FormsModule],
      providers:[EmployeeServiceService]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EmployeeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
