import { TestBed } from '@angular/core/testing';

import { NumberapisvcService } from './numberapisvc.service';

describe('NumberapisvcService', () => {
  let service: NumberapisvcService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(NumberapisvcService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
