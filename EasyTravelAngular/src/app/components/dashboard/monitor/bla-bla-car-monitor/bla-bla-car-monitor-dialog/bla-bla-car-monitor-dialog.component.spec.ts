import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BlaBlaCarMonitorDialogComponent } from './bla-bla-car-monitor-dialog.component';

describe('BlaBlaCarMonitorDialogComponent', () => {
  let component: BlaBlaCarMonitorDialogComponent;
  let fixture: ComponentFixture<BlaBlaCarMonitorDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BlaBlaCarMonitorDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BlaBlaCarMonitorDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
