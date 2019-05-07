import { TestBed } from '@angular/core/testing';

import { BlaBlaCarMonitorService } from './bla-bla-car-monitor.service';

describe('BlaBlaCarMonitorService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: BlaBlaCarMonitorService = TestBed.get(BlaBlaCarMonitorService);
    expect(service).toBeTruthy();
  });
});
