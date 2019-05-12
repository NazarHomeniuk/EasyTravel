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
  waitTime: number[] = [];
  isDisabled = false;

  constructor() { }

  ngOnInit() {
    this.startLocation = this.locations[0];
    this.finishLocation = this.locations[this.locations.length - 1];
    this.locations.splice(0, 1);
    this.locations.splice(this.locations.length - 1, 1);
  }

  submit(trip: BaseTrip) {
    var from, to, date, time;
    switch(trip.type) {
      case TripType.BlaBlaCar:
      from = trip.car.arrival_place.city_name;
      to = this.finishLocation;
      trip.arrivalDate = trip.car.arrival_date;
      trip.departureDate = trip.car.departure_date;
      break;
      case TripType.Bus:
      from = trip.bus.to;
      to = this.finishLocation;
      trip.arrivalDate = trip.bus.arrivalDate;
      trip.departureDate = trip.bus.departureDate;
      break;
      case TripType.Railway:
      from = trip.train.to.station;
      to = this.finishLocation;
      trip.arrivalDate = trip.train.arrivalDate;
      trip.departureDate = trip.train.departureDate;
      break;
    }

    if (this.trips.length > 0) {
      var previousTrip = this.trips[this.trips.length - 1];
      let time = Math.floor((new Date(trip.departureDate).getTime() - new Date(previousTrip.arrivalDate).getTime())  / 1000 / 60 / 60);
      this.waitTime.push(time);
    }

    this.trips.push(trip);

    if (from.toLowerCase() == to.toLowerCase()) {
      this.isDisabled = true;
      return;
    }

    this.carComponent.refresh(from, to, trip.arrivalDate, time);
    this.busCardComponent.refresh(from, to, trip.arrivalDate, time);
    this.railwayComponent.refresh(from, to, trip.arrivalDate, time);
  }

}
