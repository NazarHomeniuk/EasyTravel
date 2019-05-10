import { TestBed } from '@angular/core/testing';

import { AuthorizedGuardService } from './authorized-guard.service';

describe('AuthorizedGuardService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: AuthorizedGuardService = TestBed.get(AuthorizedGuardService);
    expect(service).toBeTruthy();
  });
});
