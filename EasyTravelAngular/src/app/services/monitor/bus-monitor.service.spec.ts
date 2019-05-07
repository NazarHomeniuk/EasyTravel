import { TestBed } from '@angular/core/testing';

import { BusMonitorService } from './bus-monitor.service';

describe('BusMonitorService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: BusMonitorService = TestBed.get(BusMonitorService);
    expect(service).toBeTruthy();
  });
});
