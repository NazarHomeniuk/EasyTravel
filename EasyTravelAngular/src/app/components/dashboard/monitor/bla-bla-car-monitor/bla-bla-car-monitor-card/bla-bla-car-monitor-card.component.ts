import { Component, OnInit, Input } from '@angular/core';
import { BlaBlaCarMonitor } from 'src/app/models';
import { BlaBlaCarMonitorService } from 'src/app/services';

@Component({
  selector: 'app-bla-bla-car-monitor-card',
  templateUrl: './bla-bla-car-monitor-card.component.html',
  styleUrls: ['./bla-bla-car-monitor-card.component.css']
})
export class BlaBlaCarMonitorCardComponent implements OnInit {

  @Input() monitor: BlaBlaCarMonitor;

  constructor(private monitorService: BlaBlaCarMonitorService) { }

  ngOnInit() {
  }

  remove() {
    console.log("test");
    this.monitorService.remove(this.monitor.guid).subscribe(result => {
    });
  }
}
