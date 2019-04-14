import { Component, OnInit } from '@angular/core';
import { LocationsService } from 'src/app/services';
import { FormControl } from '@angular/forms';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-find-form',
  templateUrl: './find-form.component.html',
  styleUrls: ['./find-form.component.css']
})
export class FindFormComponent implements OnInit {
  
  fromInput = new FormControl();
  toInput = new FormControl();

  options: Observable<string[]>;

  constructor(private locationsService: LocationsService) { }

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

  private autocomplete(value: string) {
    const filterValue = value.toLowerCase();

    this.options = this.locationsService.autocomplete(filterValue);
  }

}
