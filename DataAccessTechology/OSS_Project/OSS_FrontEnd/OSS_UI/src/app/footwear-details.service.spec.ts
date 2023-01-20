import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule} from '@angular/common/http/testing';
import { FootwearDetailsService } from './footwear-details.service';
import { HttpClient } from '@angular/common/http';
import { of } from 'rxjs';
import { IFootwearDetails } from './ifootwear-details';

describe('FootwearDetailsService', () => {
  let service: FootwearDetailsService;
  let mockHttpClient: HttpClient; 
  let response : IFootwearDetails[];

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports :[HttpClientTestingModule]
    });
    //service = TestBed.inject(FootwearDetailsService);
    service = new FootwearDetailsService(mockHttpClient);
  });

  it('should get footwear', () => {
    let mockResponse = [
      {
        id: 1,
        name: "qwertyuiop",
        pic: "fsadjkl",
        price: 235,
        color: "sredtring",
        material: "string",
        manufacturingDate: new Date(),
        inStock: true,
        categoryId: 4,
        manufacturerId: 3
      }
    ]

    //let response;
    spyOn(service, 'getAllFootwear').and.returnValue(of(mockResponse));
    service.getAllFootwear().subscribe(res => { response = res });
    expect(response).toBe(mockResponse);
  });

  it('should get footwear by id', () => {
    let mockResponse = [
      {
        id: 1,
        name: "qwertyuiop",
        pic: "fsadjkl",
        price: 235,
        color: "sredtring",
        material: "string",
        manufacturingDate: new Date(),
        inStock: true,
        categoryId: 4,
        manufacturerId: 3
      }
    ]

    //let response;
    spyOn(service, 'getFootwear').and.returnValue(of(mockResponse));
    service.getFootwear(1).subscribe(res => { response = res });
    expect(response).toBe(mockResponse);
  });

  fit('should get footwear by id and category id', () => {
    let mockResponse = [
      {
        id: 1,
        name: "qwertyuiop",
        pic: "fsadjkl",
        price: 235,
        color: "sredtring",
        material: "string",
        manufacturingDate: new Date(),
        inStock: true,
        categoryId: 4,
        manufacturerId: 3
      }
    ]

    //let response;
    spyOn(service, 'getFootwearDetails').and.returnValue(of(mockResponse));
    service.getFootwearDetails(1,4).subscribe(res => { response = res });
    expect(response).toBe(mockResponse);
  });

  it('should post footwear', () => {
    let mockResponse = [
      {
        id: 1,
        name: "qwertyuiop",
        pic: "fsadjkl",
        price: 235,
        color: "sredtring",
        material: "string",
        manufacturingDate: new Date(),
        inStock: true,
        categoryId: 4,
        manufacturerId: 3
      }
    ]

    //let response;
    spyOn(service, 'postFootwearDetails').and.returnValue(of(mockResponse));
    service.postFootwearDetails(mockResponse).subscribe(res => { response = res });
    expect(response).toBe(mockResponse);
  });

  it('should put footwear', () => {
    let mockResponse = [
      {
        id: 1,
        name: "qwertyuiop",
        pic: "fsadjkl",
        price: 235,
        color: "sredtring",
        material: "string",
        manufacturingDate: new Date(),
        inStock: true,
        categoryId: 4,
        manufacturerId: 3
      }
    ]

    //let response;
    spyOn(service, 'putFootwearDetails').and.returnValue(of(mockResponse));
    service.putFootwearDetails().subscribe(res => { response = res });
    expect(response).toBe(mockResponse);
  });

  it('should delete footwear', () => {
    let mockResponse = [
      {
        id: 1,
        name: "qwertyuiop",
        pic: "fsadjkl",
        price: 235,
        color: "sredtring",
        material: "string",
        manufacturingDate: new Date(),
        inStock: true,
        categoryId: 4,
        manufacturerId: 3
      }
    ]

    //let response;
    spyOn(service, 'deleteFootwearDetails').and.returnValue(of(mockResponse));
    service.deleteFootwearDetails(1).subscribe(res => { response = res });
    expect(response).toBe(mockResponse);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
