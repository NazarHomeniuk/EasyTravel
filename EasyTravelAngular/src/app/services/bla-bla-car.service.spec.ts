import { TestBed } from '@angular/core/testing';

import { BlaBlaCarService } from './bla-bla-car.service';

describe('BlaBlaCarService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: BlaBlaCarService = TestBed.get(BlaBlaCarService);
    expect(service).toBeTruthy();
  });
});
