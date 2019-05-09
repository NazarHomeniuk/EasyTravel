import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from 'src/app/models';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ProfileService {

  constructor(private httpClient: HttpClient) { }

  getUser() : Observable<User> {
    return this.httpClient.get<User>(`${environment.API_URL}account/currentUser`);
  }

  cofnirmEmail() : Observable<any> {
    return this.httpClient.post(`${environment.API_URL}account/verifyEmail`, null);
  }

  confirmEmailCode(code: number) : Observable<any> {
    return this.httpClient.get(`${environment.API_URL}account/verifyEmailCode?code=${code}`);
  }

  confirmNumber() : Observable<any> {
    return this.httpClient.post(`${environment.API_URL}account/verifyNumber`, null);
  }

  confirmNumberCode(code: number) : Observable<any> {
    return this.httpClient.get(`${environment.API_URL}account/verifyNumberCode?code=${code}`);
  }

  changeEmailNotification() {
    return this.httpClient.post(`${environment.API_URL}account/changeEmailNotification`, {});
  }

  changeSmsNotification() {
    return this.httpClient.post(`${environment.API_URL}account/changeSmsNotification`, {});
  }
}
