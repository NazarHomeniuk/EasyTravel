import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BlaBlaCarMonitorCardComponent } from './bla-bla-car-monitor-card.component';

describe('BlaBlaCarMonitorCardComponent', () => {
  let component: BlaBlaCarMonitorCardComponent;
  let fixture: ComponentFixture<BlaBlaCarMonitorCardComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BlaBlaCarMonitorCardComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BlaBlaCarMonitorCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
