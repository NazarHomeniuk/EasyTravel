import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { Time } from '@angular/common';
import { BaseTrip, TripType, CustomTime } from 'src/app/models';
import { BlaBlaCarCardComponent } from './bla-bla-car-card/bla-bla-car-card.component';
import { RailwayCardComponent } from './railway-card/railway-card.component';
import { BusCardComponent } from './bus-card/bus-card.component';

@Component({
  selector: 'app-trips',
  templateUrl: './trips.component.html',
  styleUrls: ['./trips.component.css']
})
export class TripsComponent implements OnInit {

  @ViewChild(BlaBlaCarCardComponent) private carComponent: BlaBlaCarCardComponent;
  @ViewChild(RailwayCardComponent) private railwayComponent: RailwayCardComponent;
  @ViewChild(BusCardComponent) private busCardComponent: BusCardComponent;

  @Input() locations: string[];
  @Input() date: Date;
  @Input() time: Time;
  startLocation: string;
  finishLocation: string;
  trips: BaseTrip[] = [];
  isDisabled = false;

  constructor() { }

  ngOnInit() {
    this.startLocation = this.locations[0];
    this.finishLocation = this.locations[this.locations.length - 1];
    this.locations.splice(0, 1);
    this.locations.splice(this.locations.length - 1, 1);
  }

  submit(trip: BaseTrip) {
    this.trips.push(trip);
    var from, to, date, time;
    console.log(trip);
    switch(trip.type) {
      case TripType.BlaBlaCar:
      from = trip.car.arrival_place.city_name;
      to = this.finishLocation;
      date = new Date(trip.car.arrival_date);
      break;
      case TripType.Bus:
      from = trip.bus.to;
      to = this.finishLocation;
      date = new Date(trip.bus.arrivalDate);
      break;
      case TripType.Railway:
      console.log(trip.train);
      from = trip.train.to.station;
      to = this.finishLocation;
      date = new Date(trip.train.to.srcDate);
      break;
    }

    if (from.toLowerCase() == to.toLowerCase()) {
      this.isDisabled = true;
      return;
    }

    this.carComponent.refresh(from, to, date, time);
    this.busCardComponent.refresh(from, to, date, time);
    this.railwayComponent.refresh(from, to, date, time);
  }

}
