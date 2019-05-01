import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { LocationsService } from 'src/app/services';
import { Observable } from 'rxjs';
import { FormControl } from '@angular/forms';


@Component({
  selector: 'app-find-form',
  templateUrl: './find-form.component.html',
  styleUrls: ['./find-form.component.css']
})
export class FindFormComponent implements OnInit {
  
  fromInput = new FormControl();
  toInput = new FormControl();
  dateInput = new FormControl();
  timeInput = new FormControl();

  minDate = new Date(Date.now());
  @Output() submitButton = new EventEmitter();
  
  options: Observable<string[]>;

  constructor(private locationsService: LocationsService) { 

  }

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

  submit() {
    this.submitButton.emit({ 
      from: this.fromInput.value, 
      to: this.toInput.value,
      date: this.dateInput.value,
      time: this.timeInput.value 
    });
  }

  private autocomplete(value: string) {
    const filterValue = value.toLowerCase();
    this.options = this.locationsService.autocomplete(filterValue);
  }
}
