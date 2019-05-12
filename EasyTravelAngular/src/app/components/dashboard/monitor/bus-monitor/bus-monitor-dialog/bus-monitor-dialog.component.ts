import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { BusMonitorService, LocationsService } from 'src/app/services';
import { MatDialogRef } from '@angular/material/dialog';
import { BusMonitor } from 'src/app/models';

@Component({
  selector: 'app-bus-monitor-dialog',
  templateUrl: './bus-monitor-dialog.component.html',
  styleUrls: ['./bus-monitor-dialog.component.css']
})
export class BusMonitorDialogComponent implements OnInit {

  fromInput = new FormControl('', Validators.required);
  toInput = new FormControl('', Validators.required);
  dateInput = new FormControl('', Validators.required);
  timeInput = new FormControl('', Validators.required);

  options: Observable<string[]>;

  minDate = new Date(Date.now());
  
  constructor(public dialogRef: MatDialogRef<BusMonitorDialogComponent>, private locationsService: LocationsService, private busMonitorService: BusMonitorService) { }

  ngOnInit() {
    this.fromInput.valueChanges.subscribe(prefix => {
      if (prefix.length != 0) {
        this.autocomplete(prefix)
      }
    });
    this.toInput.valueChanges.subscribe(prefix => {
      if (prefix.length != 0) {
        this.autocomplete(prefix)
      }
    });
  }

  create() {
    var monitor = new BusMonitor();
    monitor.from = this.fromInput.value;
    monitor.to = this.toInput.value;
    let time = this.timeInput.value;
    let hours = time.toString().split(':')[0];
    let minutes = time.toString().split(':')[1];
    var date = this.dateInput.value;
    date.setHours(+hours);
    date.setMinutes(+minutes);
    monitor.departureDate = date;
    console.log(monitor);
    this.busMonitorService.create(monitor).subscribe(data => {
      this.dialogRef.close();
    });
  }

  isValid() {
    return this.fromInput.valid && this.toInput.valid && this.dateInput.valid && this.timeInput.valid;
  }

  private autocomplete(value: string) {
    const filterValue = value.toLowerCase();
    this.options = this.locationsService.autocomplete(filterValue);
  }

}
