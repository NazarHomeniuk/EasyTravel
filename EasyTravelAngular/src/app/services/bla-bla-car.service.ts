import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Trip, Request } from '../models';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class BlaBlaCarService {

  constructor(private httpClient: HttpClient) { }

  getAllCars(request: Request) : Observable<Trip[]> {
    return this.httpClient.post<Trip[]>(`${environment.API_URL}blablacar/findAll`, request);
  }
}
