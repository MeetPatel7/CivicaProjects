import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FormsModule,NgForm } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { Route, Router } from '@angular/router';
import { EmployeeData } from '../employee-data.model';
import { EmployeeServiceService } from '../employee-service.service';
import { EmployeeFormComponent } from './employee-form.component';
import { HttpClientTestingModule } from '@angular/common/http/testing';

describe('EmployeeFormComponent', () => {
  let component: EmployeeFormComponent;
  let fixture: ComponentFixture<EmployeeFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EmployeeFormComponent ],
      imports:[HttpClientTestingModule,FormsModule],
      providers:[EmployeeServiceService]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EmployeeFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
