import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BlaBlaCarMonitorComponent } from './bla-bla-car-monitor.component';

describe('BlaBlaCarMonitorComponent', () => {
  let component: BlaBlaCarMonitorComponent;
  let fixture: ComponentFixture<BlaBlaCarMonitorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BlaBlaCarMonitorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BlaBlaCarMonitorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
