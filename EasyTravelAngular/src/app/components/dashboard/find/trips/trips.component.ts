import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-trips',
  templateUrl: './trips.component.html',
  styleUrls: ['./trips.component.css']
})
export class TripsComponent implements OnInit {

  @Input() locations: string[];
  
  constructor() { }

  ngOnInit() {
  }

}
