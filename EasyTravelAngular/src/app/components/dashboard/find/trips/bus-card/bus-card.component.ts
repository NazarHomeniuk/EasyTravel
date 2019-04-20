import { Component, OnInit, Input } from '@angular/core';
import { BusService } from 'src/app/services';
import { Time } from '@angular/common';
import { BusTrip, Request } from 'src/app/models';

@Component({
  selector: 'app-bus-card',
  templateUrl: './bus-card.component.html',
  styleUrls: ['./bus-card.component.css']
})
export class BusCardComponent implements OnInit {

  constructor(private busService: BusService) { }
  @Input() from: string;
  @Input() to: string;
  @Input() date: Date;
  @Input() time: Time;
  buses: BusTrip[];
  isLoading = true;

  ngOnInit() {
  }

  busPanelClick() {
    if (this.buses != null) return;
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
}
