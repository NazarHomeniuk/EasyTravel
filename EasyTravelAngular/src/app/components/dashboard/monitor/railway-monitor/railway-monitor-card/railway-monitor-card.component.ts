import { Component, OnInit, Input } from '@angular/core';
import { RailwayMonitor } from 'src/app/models';

@Component({
  selector: 'app-railway-monitor-card',
  templateUrl: './railway-monitor-card.component.html',
  styleUrls: ['./railway-monitor-card.component.css']
})
export class RailwayMonitorCardComponent implements OnInit {

  @Input() monitor: RailwayMonitor;

  constructor() { }

  ngOnInit() {
  }

}
