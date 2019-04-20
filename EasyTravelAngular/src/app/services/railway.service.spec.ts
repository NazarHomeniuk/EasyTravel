import { TestBed } from '@angular/core/testing';

import { RailwayService } from './railway.service';

describe('RailwayService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: RailwayService = TestBed.get(RailwayService);
    expect(service).toBeTruthy();
  });
});
