import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Request, Train } from '../models';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class RailwayService {

  constructor(private httpClient: HttpClient) { }

  getAllTrains(request: Request) : Observable<Train[]> {
    return this.httpClient.post<Train[]>(`${environment.API_URL}railway/findAll`, request);
  }
}
