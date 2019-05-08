import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BusMonitorDialogComponent } from './bus-monitor-dialog.component';

describe('BusMonitorDialogComponent', () => {
  let component: BusMonitorDialogComponent;
  let fixture: ComponentFixture<BusMonitorDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BusMonitorDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BusMonitorDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
