import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { LocationsService, RailwayMonitorService } from 'src/app/services';
import { FormControl, Validators } from '@angular/forms';
import { RailwayMonitor } from 'src/app/models';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-railway-monitor-dialog',
  templateUrl: './railway-monitor-dialog.component.html',
  styleUrls: ['./railway-monitor-dialog.component.css']
})
export class RailwayMonitorDialogComponent implements OnInit {

  fromInput = new FormControl('', Validators.required);
  toInput = new FormControl('', Validators.required);
  dateInput = new FormControl('', Validators.required);
  timeInput = new FormControl('', Validators.required);
  minPlacesInput = new FormControl('', Validators.required);

  options: Observable<string[]>;

  minDate = new Date(Date.now());

  constructor(public dialogRef: MatDialogRef<RailwayMonitorDialogComponent>, private locationsService: LocationsService, private railwayMonitorService: RailwayMonitorService) { }

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
    var monitor = new RailwayMonitor();
    monitor.from = this.fromInput.value;
    monitor.to = this.toInput.value;
    monitor.minPlaces = this.minPlacesInput.value;
    let time = this.timeInput.value;
    let hours = time.toString().split(':')[0];
    let minutes = time.toString().split(':')[1];
    monitor.departureDate = this.dateInput.value;
    monitor.departureDate.setHours(+hours);
    monitor.departureDate.setMinutes(+minutes);
    this.railwayMonitorService.create(monitor).subscribe(data => {
      this.dialogRef.close();
    });
  }

  isValid() {
    return this.fromInput.valid && this.toInput.valid && this.dateInput.valid && this.timeInput.valid && this.minPlacesInput.valid;
  }

  private autocomplete(value: string) {
    const filterValue = value.toLowerCase();
    this.options = this.locationsService.autocomplete(filterValue);
  }

}
