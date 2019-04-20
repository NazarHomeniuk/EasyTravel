import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { BusTrip, Request } from '../models';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class BusService {

  constructor(private httpClient: HttpClient) { }

  getAllBuses(request: Request) : Observable<BusTrip[]> {
    return this.httpClient.post<BusTrip[]>(`${environment.API_URL}bus/findAll`, request);
  }
}
