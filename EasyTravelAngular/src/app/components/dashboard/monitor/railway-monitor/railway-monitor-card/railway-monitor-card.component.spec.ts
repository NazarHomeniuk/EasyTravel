import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RailwayMonitorCardComponent } from './railway-monitor-card.component';

describe('RailwayMonitorCardComponent', () => {
  let component: RailwayMonitorCardComponent;
  let fixture: ComponentFixture<RailwayMonitorCardComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RailwayMonitorCardComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RailwayMonitorCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
