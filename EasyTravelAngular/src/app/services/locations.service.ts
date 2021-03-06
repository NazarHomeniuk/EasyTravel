import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LocationsService {

  constructor(private httpClient: HttpClient) { }

  getLocations() : Observable<string[]> {
    return this.httpClient.get<string[]>(`${environment.API_URL}locations/locations`);
  }

  getLocationsBetween(from: string, to: string) : Observable<string[]> {
    return this.httpClient.get<string[]>(`${environment.API_URL}maps/between?from=${from}&to=${to}`);
  }

  autocomplete(prefix: string) : Observable<string[]> {
    return this.httpClient.get<string[]>(`${environment.API_URL}locations/autocomplete?prefix=${prefix}`);
  }
}
