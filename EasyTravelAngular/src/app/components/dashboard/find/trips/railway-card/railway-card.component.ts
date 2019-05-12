import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { RailwayService } from 'src/app/services';
import { Request, Train, BaseTrip, TripType } from 'src/app/models';
import { Time } from '@angular/common';

@Component({
  selector: 'app-railway-card',
  templateUrl: './railway-card.component.html',
  styleUrls: ['./railway-card.component.css']
})
export class RailwayCardComponent implements OnInit {

  constructor(private railwayService: RailwayService) { }

  @Output() submitButton = new EventEmitter();
  @Input() from: string;
  @Input() to: string;
  @Input() date: string;
  @Input() time: Time;
  trains: Train[];
  isLoading = true;
  isOpened = false;

  ngOnInit() {
  }

  trainPanelClick() {
    if (this.trains != null) return;
    this.isOpened = true;
    var request = new Request();
    request.from = this.from;
    request.to = this.to;
    request.date = this.date;
    request.time = this.time;
    this.railwayService.getAllTrains(request).subscribe(trains => {
      this.isLoading = false;
      this.trains = trains;
    })
  }

  refresh(from: string, to: string, date: string, time: Time) {
    this.from = from;
    this.to = to;
    this.date = date;
    if (!this.isOpened) return;
    this.trains.length = 0;
    this.isLoading = true;
    var request = new Request();
    request.from = this.from;
    request.to = this.to;
    request.date = this.date;
    this.railwayService.getAllTrains(request).subscribe(trains => {
      this.trains = trains;
      this.isLoading = false;
    })
  }

  submit(train: Train) {
    var trip = new BaseTrip();
    trip.type = TripType.Railway;
    trip.train = train;
    this.submitButton.emit(trip);
    this.trains.length = 0;
  }

}
