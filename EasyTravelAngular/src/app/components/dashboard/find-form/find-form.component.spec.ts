import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FindFormComponent } from './find-form.component';

describe('FindFormComponent', () => {
  let component: FindFormComponent;
  let fixture: ComponentFixture<FindFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FindFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FindFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
