import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { RailwayService, RailwayMonitorService } from 'src/app/services';
import { Request, Train, BaseTrip, TripType, RailwayMonitor } from 'src/app/models';
import { Time } from '@angular/common';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-railway-card',
  templateUrl: './railway-card.component.html',
  styleUrls: ['./railway-card.component.css']
})
export class RailwayCardComponent implements OnInit {

  constructor(private railwayService: RailwayService, private monitoringService: RailwayMonitorService, private snackBar: MatSnackBar) { }

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

  createMonitoring() {
    var monitoring = new RailwayMonitor();
    monitoring.from = this.from;
    monitoring.to = this.to;
    monitoring.departureDate = this.date;
    this.monitoringService.create(monitoring).subscribe(result => {
      this.snackBar.open("Моніторинг створено", "Закрити", {
        duration: 3000
      });
    },
      error => {
        this.snackBar.open(error, "Закрити", {
          duration: 3000
        });
      });
  }

}
