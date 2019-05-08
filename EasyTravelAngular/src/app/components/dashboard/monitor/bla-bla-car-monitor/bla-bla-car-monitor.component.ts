import { Component, OnInit } from '@angular/core';
import { BlaBlaCarMonitorService } from 'src/app/services';
import { BlaBlaCarMonitor } from 'src/app/models';

@Component({
  selector: 'app-bla-bla-car-monitor',
  templateUrl: './bla-bla-car-monitor.component.html',
  styleUrls: ['./bla-bla-car-monitor.component.css']
})
export class BlaBlaCarMonitorComponent implements OnInit {

  monitor: BlaBlaCarMonitor[];

  constructor(private monitorService: BlaBlaCarMonitorService) { }

  ngOnInit() {
    this.monitorService.getAll().subscribe(data => {
      this.monitor = data;
    });
  }

}
