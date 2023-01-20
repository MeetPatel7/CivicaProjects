import { HttpClient } from '@angular/common/http';
import { TestBed } from '@angular/core/testing';

import { DepartmentServiceService } from './department-service.service';

describe('DepartmentServiceService', () => {
  let departmentService: DepartmentServiceService;
  let mockHttpClient: HttpClient;

  beforeEach(() => {
    //TestBed.configureTestingModule({});
    //service = TestBed.inject(DepartmentServiceService);
    departmentService = new DepartmentServiceService(mockHttpClient);
  });

  it('should be created', () => {
    expect(departmentService).toBeTruthy();
  });
});
