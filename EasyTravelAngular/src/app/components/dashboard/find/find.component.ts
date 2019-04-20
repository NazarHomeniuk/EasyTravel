import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { LocationsService } from 'src/app/services';
import { Time } from '@angular/common';

@Component({
  selector: 'app-find',
  templateUrl: './find.component.html',
  styleUrls: ['./find.component.css']
})
export class FindComponent implements OnInit {

  isLoading = false;
  isFound = false;
  locationsBetween: string[];
  date: Date;
  time: Time;

  constructor(private locationsService: LocationsService) { }

  ngOnInit() {
    this.isLoading = false;
    this.isFound = false;
  }

  find(values: any) {
    this.isLoading = true;
    this.locationsService.getLocationsBetween(values.from, values.to).subscribe(locations => {
      this.isLoading = false;
      this.isFound = true;
      this.locationsBetween = locations;
      this.date = values.date;
      this.time = values.time;
    });
  }
}
