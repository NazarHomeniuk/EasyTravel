import { TestBed } from '@angular/core/testing';

import { RailwayMonitorService } from './railway-monitor.service';

describe('RailwayMonitorService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: RailwayMonitorService = TestBed.get(RailwayMonitorService);
    expect(service).toBeTruthy();
  });
});
