import { HttpClientModule } from '@angular/common/http';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FormsModule } from '@angular/forms';
import { RouterTestingModule } from '@angular/router/testing';

import { FootwearDetailsComponent } from './footwear-details.component';

describe('FootwearDetailsComponent', () => {
  let component: FootwearDetailsComponent;
  let fixture: ComponentFixture<FootwearDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FootwearDetailsComponent ],
      imports: [HttpClientModule,FormsModule,RouterTestingModule]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FootwearDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
