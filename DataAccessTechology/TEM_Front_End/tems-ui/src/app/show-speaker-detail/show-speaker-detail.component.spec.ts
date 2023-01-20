import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowSpeakerDetailComponent } from './show-speaker-detail.component';

describe('ShowSpeakerDetailComponent', () => {
  let component: ShowSpeakerDetailComponent;
  let fixture: ComponentFixture<ShowSpeakerDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowSpeakerDetailComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShowSpeakerDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
