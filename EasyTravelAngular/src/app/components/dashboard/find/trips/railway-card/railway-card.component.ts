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
  @Input() date: Date;
  @Input() time: Time;
  trains: Train[];
  isLoading = true;

  ngOnInit() {
  }

  trainPanelClick() {
    if (this.trains != null) return;
    var request = new Request();
    request.from = this.from;
    request.to = this.to;
    request.date = this.date;
    request.time = this.time;
    console.log(request);
    this.railwayService.getAllTrains(request).subscribe(trains => {
      this.isLoading = false;
      console.log(trains);
      this.trains = trains;
    })
  }

  submit(train: Train) {
    var trip = new BaseTrip();
    trip.type = TripType.Railway;
    trip.train = train;
    this.submitButton.emit(trip);
  }

}
