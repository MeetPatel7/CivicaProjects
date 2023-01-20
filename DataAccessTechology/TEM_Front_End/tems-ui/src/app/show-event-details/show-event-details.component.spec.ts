import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowEventDetailsComponent } from './show-event-details.component';

describe('ShowEventDetailsComponent', () => {
  let component: ShowEventDetailsComponent;
  let fixture: ComponentFixture<ShowEventDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowEventDetailsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShowEventDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
