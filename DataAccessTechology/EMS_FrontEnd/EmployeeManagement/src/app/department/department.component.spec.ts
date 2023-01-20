import { Component, OnInit } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { DepartmentData } from '../department-data.model';
import { DepartmentServiceService } from '../department-service.service';import { ComponentFixture, TestBed } from '@angular/core/testing';
import { DepartmentComponent } from './department.component';
import { HttpClient } from '@angular/common/http';
import { HttpClientTestingModule} from '@angular/common/http/testing';

describe('DepartmentComponent', () => {
  let component: DepartmentComponent;
  let fixture: ComponentFixture<DepartmentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DepartmentComponent ],
      imports:[HttpClientTestingModule,FormsModule],
      providers:[DepartmentServiceService]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DepartmentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
