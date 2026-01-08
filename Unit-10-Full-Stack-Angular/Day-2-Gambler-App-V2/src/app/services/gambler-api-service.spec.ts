import { TestBed } from '@angular/core/testing';

import { GamblerApiService } from './gambler-api-service';

describe('GamblerApiService', () => {
  let service: GamblerApiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GamblerApiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
