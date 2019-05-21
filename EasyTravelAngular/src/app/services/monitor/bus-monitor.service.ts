import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BusMonitor } from 'src/app/models';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class BusMonitorService {

  constructor(private httpClient: HttpClient) { }

  getAll() : Observable<BusMonitor[]> {
    return this.httpClient.get<BusMonitor[]>(`${environment.API_URL}busMonitoring/getAll`);
  }

  create(monitor: BusMonitor) : Observable<any> {
    return this.httpClient.post(`${environment.API_URL}busMonitoring/create`, monitor);
  }

  remove(guid: string) : Observable<any> {
    return this.httpClient.post(`${environment.API_URL}busMonitoring/remove`, guid);
  }
}
