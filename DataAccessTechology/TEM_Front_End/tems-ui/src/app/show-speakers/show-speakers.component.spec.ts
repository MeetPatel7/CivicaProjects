import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowSpeakersComponent } from './show-speakers.component';

describe('ShowSpeakersComponent', () => {
  let component: ShowSpeakersComponent;
  let fixture: ComponentFixture<ShowSpeakersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowSpeakersComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShowSpeakersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
