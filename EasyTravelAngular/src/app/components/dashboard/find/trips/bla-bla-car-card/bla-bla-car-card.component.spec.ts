import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BlaBlaCarCardComponent } from './bla-bla-car-card.component';

describe('BlaBlaCarCardComponent', () => {
  let component: BlaBlaCarCardComponent;
  let fixture: ComponentFixture<BlaBlaCarCardComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BlaBlaCarCardComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BlaBlaCarCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
