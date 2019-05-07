import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RailwayMonitorComponent } from './railway-monitor.component';

describe('RailwayMonitorComponent', () => {
  let component: RailwayMonitorComponent;
  let fixture: ComponentFixture<RailwayMonitorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RailwayMonitorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RailwayMonitorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
