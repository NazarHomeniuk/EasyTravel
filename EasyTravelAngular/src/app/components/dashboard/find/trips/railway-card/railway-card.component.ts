import { Component, OnInit, Input } from '@angular/core';
import { RailwayService } from 'src/app/services';
import { Request, Train } from 'src/app/models';
import { Time } from '@angular/common';

@Component({
  selector: 'app-railway-card',
  templateUrl: './railway-card.component.html',
  styleUrls: ['./railway-card.component.css']
})
export class RailwayCardComponent implements OnInit {

  constructor(private railwayService: RailwayService) { }
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

}
