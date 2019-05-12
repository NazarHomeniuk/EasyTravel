import { Component, OnInit } from '@angular/core';
import { BusMonitorService } from 'src/app/services';
import { BusMonitor } from 'src/app/models';
import { MatDialog } from '@angular/material/dialog';
import { BusMonitorDialogComponent } from './bus-monitor-dialog/bus-monitor-dialog.component';

@Component({
  selector: 'app-bus-monitor',
  templateUrl: './bus-monitor.component.html',
  styleUrls: ['./bus-monitor.component.css']
})
export class BusMonitorComponent implements OnInit {

  monitor: BusMonitor[];

  isLoading = true;

  constructor(private monitorService: BusMonitorService, private dialog: MatDialog) { }

  ngOnInit() {
    this.monitorService.getAll().subscribe(data => {
      this.monitor = data;
      this.isLoading = false;
    });
  }

  create() {
    var monitorData = new BusMonitor();
    const dialogRef = this.dialog.open(BusMonitorDialogComponent, {
      width: '250px',
      data: monitorData
    });

    dialogRef.afterClosed().subscribe(result => {
      this.isLoading = true;
      this.monitorService.getAll().subscribe(data => {
        this.monitor = data;
        this.isLoading = false;
      })
    });
  }

}
