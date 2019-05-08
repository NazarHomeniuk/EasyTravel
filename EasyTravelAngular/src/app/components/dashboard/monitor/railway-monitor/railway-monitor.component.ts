import { Component, OnInit } from '@angular/core';
import { RailwayMonitorService } from 'src/app/services';
import { RailwayMonitor } from 'src/app/models';
import { MatDialog } from '@angular/material/dialog';
import { RailwayMonitorDialogComponent } from './railway-monitor-dialog/railway-monitor-dialog.component';

@Component({
  selector: 'app-railway-monitor',
  templateUrl: './railway-monitor.component.html',
  styleUrls: ['./railway-monitor.component.css']
})
export class RailwayMonitorComponent implements OnInit {

  monitor: RailwayMonitor[];

  constructor(private monitorService: RailwayMonitorService, private dialog: MatDialog) { }

  ngOnInit() {
    this.monitorService.getAll().subscribe(data => {
      this.monitor = data;
    });
  }

  create() {
    var monitorData = new RailwayMonitor();
    const dialogRef = this.dialog.open(RailwayMonitorDialogComponent, {
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
