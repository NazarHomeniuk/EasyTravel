import { Component, OnInit, Input } from '@angular/core';
import { BlaBlaCarMonitor } from 'src/app/models';

@Component({
  selector: 'app-bla-bla-car-monitor-card',
  templateUrl: './bla-bla-car-monitor-card.component.html',
  styleUrls: ['./bla-bla-car-monitor-card.component.css']
})
export class BlaBlaCarMonitorCardComponent implements OnInit {

  @Input() monitor: BlaBlaCarMonitor;

  constructor() { }

  ngOnInit() {
  }

}
