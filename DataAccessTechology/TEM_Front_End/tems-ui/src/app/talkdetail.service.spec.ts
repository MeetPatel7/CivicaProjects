import { TestBed } from '@angular/core/testing';

import { TalkdetailService } from './talkdetail.service';

describe('TalkdetailService', () => {
  let service: TalkdetailService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TalkdetailService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
