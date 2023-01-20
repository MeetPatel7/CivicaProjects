import { HttpClientModule } from '@angular/common/http';
import { ComponentFixture, fakeAsync, TestBed, tick } from '@angular/core/testing';
import { FormsModule } from '@angular/forms';
import { RouterTestingModule } from '@angular/router/testing';
import { delay, of } from 'rxjs';
import { FootwearDetailsService } from '../footwear-details.service';
import { IFootwearDetails } from '../ifootwear-details';

import { FootwearComponent } from './footwear.component';

describe('FootwearComponent', () => {
  let component: FootwearComponent;
  let fixture: ComponentFixture<FootwearComponent>;
  let FootwearService :FootwearDetailsService;
  let FootwearDetails : IFootwearDetails;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FootwearComponent ],
      imports: [HttpClientModule,FormsModule,RouterTestingModule]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FootwearComponent);
    component = fixture.componentInstance;
    FootwearService = TestBed.get(FootwearDetailsService);
    //fixture.detectChanges();

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
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should get all footwears', fakeAsync(() => {
    spyOn(FootwearService, 'getAllFootwear').and.returnValue(of([FootwearDetails]).pipe(delay(1)));

    // Trigger ngOnInit()
    fixture.detectChanges();

    expect(component.footwearData).toBeUndefined();
    expect(FootwearService.getAllFootwear).toHaveBeenCalledWith();

    // Simulates the asynchronous passage of time
    tick(1);
    expect(component.footwearData).toEqual([FootwearDetails]);
  }
  ));
});
