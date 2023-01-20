import { HttpClientModule } from '@angular/common/http';
import { ComponentFixture, fakeAsync, TestBed, tick } from '@angular/core/testing';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterTestingModule } from '@angular/router/testing';
import { delay, of } from 'rxjs';
import { FootwearDetailsService } from '../footwear-details.service';
import { IFootwearDetails } from '../ifootwear-details';

import { AddFootwearComponent } from './add-footwear.component';

describe('AddFootwearComponent', () => {
  let component: AddFootwearComponent;
  let fixture: ComponentFixture<AddFootwearComponent>;
  let FootwearService :FootwearDetailsService;
  let FootwearDetails : IFootwearDetails;
  let mockResponse : IFootwearDetails[];

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddFootwearComponent ],
      imports: [HttpClientModule,FormsModule,RouterTestingModule]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddFootwearComponent);
    component = fixture.componentInstance;
    FootwearService = TestBed.get(FootwearDetailsService);
    //fixture.detectChanges();

    mockResponse = [
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
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  fit('should put footwears', fakeAsync(() => {
    spyOn(FootwearService, 'putFootwearDetails').and.returnValue(of(mockResponse).pipe(delay(1)));

    // Trigger ngOnInit()
    fixture.detectChanges();

    expect(component.footwearData).toBeUndefined();
    FootwearService.putFootwearDetails().subscribe(res => {
      expect(res).toBe(mockResponse)    })

    // Simulates the asynchronous passage of time
    tick(1);
    //expect(component.footwearData).toEqual(mockResponse);
  }
  ));

  // it('should update manufacturers', fakeAsync(() => {

  //   spyOn(manuService, 'putManuData').and.returnValue(of(expectedResult).pipe(delay(1)));

  //   fixture.detectChanges();

  //   expect(component.manufacturerList).toBeUndefined();
  //   manuService.putManuData().subscribe(res => {
  //     expect(res).toBe(expectedResult);
  //   })
  //   tick(1);
  // }
  // ));
});
