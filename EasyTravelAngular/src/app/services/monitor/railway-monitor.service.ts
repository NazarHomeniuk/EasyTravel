import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { RailwayMonitor } from 'src/app/models';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class RailwayMonitorService {

  constructor(private httpClient: HttpClient) { }

  getAll() : Observable<RailwayMonitor[]> {
    return this.httpClient.get<RailwayMonitor[]>(`${environment.API_URL}railwayMonitoring/getAll`);
  }

  create(monitor: RailwayMonitor) : Observable<any> {
    return this.httpClient.post(`${environment.API_URL}railwayMonitoring/create`, monitor);
  }

  remove(guid: string) : Observable<any> {
    return this.httpClient.post(`${environment.API_URL}railwayMonitoring/remove`, guid);
  }
}
