import { HttpClient } from '@angular/common/http';
import { TestBed } from '@angular/core/testing';

import { EmployeeServiceService } from './employee-service.service';

describe('EmployeeServiceService', () => {
  let employeeService: EmployeeServiceService;
  let mockHttpClient: HttpClient;

  beforeEach(() => {
    //TestBed.configureTestingModule({});
    //service = TestBed.inject(EmployeeServiceService);
    employeeService = new EmployeeServiceService(mockHttpClient);
  });

  it('should be return put employee', () => {
    let mockResponse = [
      { id:1,firstName:'sahdev',lastName:'patel',dateOfBirth:'2002-01-16',age:21,email:'sp@gmail.com',joinedDate:'2022-11-20',isActive:true,departmentId:2},
      { id:2,firstName:'nil',lastName:'patel',dateOfBirth:'1999-10-13',age:23,email:'np@gmail.com',joinedDate:'2022-12-15',isActive:false,departmentId:3},
      { id:3,firstName:'meet',lastName:'patel',dateOfBirth:'2000-11-20',age:22,email:'mp@gmail.com',joinedDate:'2022-07-04',isActive:true,departmentId:1}


    ]

    expect(employeeService).toBeTruthy();
  });
});
