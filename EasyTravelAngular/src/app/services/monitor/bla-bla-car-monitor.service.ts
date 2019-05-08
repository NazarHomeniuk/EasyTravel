import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BlaBlaCarMonitor } from 'src/app/models';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class BlaBlaCarMonitorService {

  constructor(private httpClient: HttpClient) { }

  getAll() : Observable<BlaBlaCarMonitor[]> {
    return this.httpClient.get<BlaBlaCarMonitor[]>(`${environment.API_URL}blaBlaCarMonitoring/getAll`);
  }

  create(monitor: BlaBlaCarMonitor) : Observable<any> {
    return this.httpClient.post(`${environment.API_URL}blaBlaCarMonitoring/create`, monitor);
  }
}
