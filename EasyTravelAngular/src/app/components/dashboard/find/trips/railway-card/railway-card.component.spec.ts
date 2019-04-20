import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RailwayCardComponent } from './railway-card.component';

describe('RailwayCardComponent', () => {
  let component: RailwayCardComponent;
  let fixture: ComponentFixture<RailwayCardComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RailwayCardComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RailwayCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
