import { TestBed } from '@angular/core/testing';

import { StudentlocalstorageService } from './studentlocalstorage.service';

describe('StudentlocalstorageService', () => {
  let service: StudentlocalstorageService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(StudentlocalstorageService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
