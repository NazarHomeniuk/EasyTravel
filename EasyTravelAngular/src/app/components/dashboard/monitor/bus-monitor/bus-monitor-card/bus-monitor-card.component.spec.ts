import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BusMonitorCardComponent } from './bus-monitor-card.component';

describe('BusMonitorCardComponent', () => {
  let component: BusMonitorCardComponent;
  let fixture: ComponentFixture<BusMonitorCardComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BusMonitorCardComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BusMonitorCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
