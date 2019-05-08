import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RailwayMonitorDialogComponent } from './railway-monitor-dialog.component';

describe('RailwayMonitorDialogComponent', () => {
  let component: RailwayMonitorDialogComponent;
  let fixture: ComponentFixture<RailwayMonitorDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RailwayMonitorDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RailwayMonitorDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
