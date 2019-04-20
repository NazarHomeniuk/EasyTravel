import { Component, OnInit, Input } from '@angular/core';
import { Time } from '@angular/common';

@Component({
  selector: 'app-trips',
  templateUrl: './trips.component.html',
  styleUrls: ['./trips.component.css']
})
export class TripsComponent implements OnInit {

  @Input() locations: string[];
  @Input() date: Date;
  @Input() time: Time;
  startLocation: string;
  finishLocation: string;

  constructor() { }

  ngOnInit() {
    this.startLocation = this.locations[0];
    this.finishLocation = this.locations[this.locations.length - 1];
    this.locations.splice(0, 1);
    this.locations.splice(this.locations.length - 1, 1);
  }


}
