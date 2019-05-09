import { Component, OnInit } from '@angular/core';
import { BlaBlaCarMonitorService } from 'src/app/services';
import { BlaBlaCarMonitor } from 'src/app/models';
import { MatDialog } from '@angular/material/dialog';
import { BlaBlaCarMonitorDialogComponent } from './bla-bla-car-monitor-dialog/bla-bla-car-monitor-dialog.component';

@Component({
  selector: 'app-bla-bla-car-monitor',
  templateUrl: './bla-bla-car-monitor.component.html',
  styleUrls: ['./bla-bla-car-monitor.component.css']
})
export class BlaBlaCarMonitorComponent implements OnInit {

  monitor: BlaBlaCarMonitor[];

  constructor(private monitorService: BlaBlaCarMonitorService, private dialog: MatDialog) { }

  ngOnInit() {
    this.monitorService.getAll().subscribe(data => {
      this.monitor = data;
    });
  }

  create() {
    var monitorData = new BlaBlaCarMonitor();
    const dialogRef = this.dialog.open(BlaBlaCarMonitorDialogComponent, {
      width: '250px',
      data: monitorData
    });

    dialogRef.afterClosed().subscribe(result => {
      this.monitorService.getAll().subscribe(data => {
        this.monitor = data;
      })
    });
  }

}
