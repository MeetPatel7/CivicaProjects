import { TestBed } from '@angular/core/testing';
import { HttpClient } from '@angular/common/http';
import { HttpClientTestingModule} from '@angular/common/http/testing';
import { CategoriesService } from './categories.service';
import { of } from 'rxjs';
import { ICategories } from './icategories';

describe('CategoriesService', () => {
  let service: CategoriesService;
  let mockHttpClient: HttpClient;
  let response: ICategories[];
  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule]
    });
    //service = TestBed.inject(CategoriesService);
    service = new CategoriesService(mockHttpClient);

  });

  it('should get all categories', () => {
    let mockResponse = [
      {
        id: 1,
        name: "men",
        pic: "fsadjkl"
      }
    ]

    //let response;
    spyOn(service, 'getCategories').and.returnValue(of(mockResponse));
    service.getCategories().subscribe(res => { response = res });
    expect(response).toBe(mockResponse);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
