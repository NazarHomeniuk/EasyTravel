import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Trip, Request, BaseTrip, TripType } from 'src/app/models';
import { BlaBlaCarService } from 'src/app/services';
import { Time } from '@angular/common';

@Component({
  selector: 'app-bla-bla-car-card',
  templateUrl: './bla-bla-car-card.component.html',
  styleUrls: ['./bla-bla-car-card.component.css']
})
export class BlaBlaCarCardComponent implements OnInit {

  constructor(private blaBlaCarService: BlaBlaCarService) { }

  @Output() submitButton = new EventEmitter();
  @Input() from: string;
  @Input() to: string;
  @Input() date: string;
  @Input() time: Time;
  cars: Trip[];
  isLoading = true;
  isOpened = false;

  ngOnInit() {
  }

  carPanelClick() {
    if (this.cars != null) return;
    this.isOpened = true;
    var request = new Request();
    request.from = this.from;
    request.to = this.to;
    request.date = this.date;
    request.time = this.time;
    console.log(request);
    this.blaBlaCarService.getAllCars(request).subscribe(cars => {
      this.cars = cars;
      this.isLoading = false;
      console.log(this.cars);
    })
  }

  refresh(from: string, to: string, date: string, time: Time) {
    this.from = from;
    this.to = to;
    this.date = date;
    if (!this.isOpened) return;
    this.cars.length = 0;
    this.isLoading = true;
    var request = new Request();
    request.from = this.from;
    request.to = this.to;
    request.date = this.date;
    this.blaBlaCarService.getAllCars(request).subscribe(cars => {
      this.cars = cars;
      this.isLoading = false;
      console.log(this.cars);
    })
  }

  submit(car: Trip) {
    var trip = new BaseTrip();
    trip.type = TripType.BlaBlaCar;
    trip.car = car;
    this.cars.length = 0;
    this.submitButton.emit(trip);
  }

}
