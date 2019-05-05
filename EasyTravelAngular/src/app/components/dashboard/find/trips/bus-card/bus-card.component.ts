import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { BusService } from 'src/app/services';
import { Time } from '@angular/common';
import { BusTrip, Request, BaseTrip, TripType } from 'src/app/models';

@Component({
  selector: 'app-bus-card',
  templateUrl: './bus-card.component.html',
  styleUrls: ['./bus-card.component.css']
})
export class BusCardComponent implements OnInit {

  constructor(private busService: BusService) { }

  @Output() submitButton = new EventEmitter();
  @Input() from: string;
  @Input() to: string;
  @Input() date: Date;
  @Input() time: Time;
  buses: BusTrip[];
  isLoading = true;
  isOpened = false;

  ngOnInit() {
  }

  busPanelClick() {
    if (this.buses != null) return;
    this.isOpened = true;
    var request = new Request();
    request.from = this.from;
    request.to = this.to;
    request.date = this.date;
    request.time = this.time;
    console.log(request);
    this.busService.getAllBuses(request).subscribe(buses => {
      this.isLoading = false;
      console.log(buses);
      this.buses = buses;
    })
  }

  refresh(from: string, to: string, date: Date, time: Time) {
    this.from = from;
    this.to = to;
    this.date = date;
    if (!this.isOpened) return;
    this.isLoading = true;
    this.buses.length = 0;
    var request = new Request();
    request.from = this.from;
    request.to = this.to;
    request.date = this.date;
    console.log(request);
    this.busService.getAllBuses(request).subscribe(buses => {
      this.buses = buses;
      this.isLoading = false;
      console.log(this.buses);
    })
  }

  submit(bus: BusTrip) {
    var trip = new BaseTrip();
    trip.type = TripType.Bus;
    trip.bus = bus;
    this.submitButton.emit(trip);
    this.buses.length = 0;
  }
}
