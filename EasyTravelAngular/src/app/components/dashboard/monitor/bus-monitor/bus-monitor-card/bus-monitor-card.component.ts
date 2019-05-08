import { Component, OnInit, Input } from '@angular/core';
import { BusMonitor } from 'src/app/models';

@Component({
  selector: 'app-bus-monitor-card',
  templateUrl: './bus-monitor-card.component.html',
  styleUrls: ['./bus-monitor-card.component.css']
})
export class BusMonitorCardComponent implements OnInit {

  @Input() monitor: BusMonitor;
  
  constructor() { }

  ngOnInit() {
  }

}
