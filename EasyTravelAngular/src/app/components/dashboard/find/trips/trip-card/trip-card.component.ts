import { Component, OnInit, Input } from '@angular/core';
import { BaseTrip } from 'src/app/models';

@Component({
  selector: 'app-trip-card',
  templateUrl: './trip-card.component.html',
  styleUrls: ['./trip-card.component.css']
})
export class TripCardComponent implements OnInit {

  constructor() { }

  @Input()trip: BaseTrip;

  ngOnInit() {
  }

}
