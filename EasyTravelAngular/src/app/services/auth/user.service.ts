import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { RegisterModel, User, LoginModel } from 'src/app/models';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  currentUser: User;

  constructor(private httpClient: HttpClient) { }

  register(registerModel: RegisterModel) {
    return this.httpClient.post<any>(`${environment.API_URL}account/register`,
      {
        Email: registerModel.email,
        Password: registerModel.password,
        ConfirmPassword: registerModel.confirmPassword,
        UserName: registerModel.userName,
        PhoneNumber: registerModel.phoneNumber
      })
      .pipe(map(user => {
        if (user && user.token) {
          localStorage.setItem('accessToken', JSON.stringify(user.token));
          this.currentUser = user;
        }

        return user;
      }));
  }

  login(loginModel: LoginModel) : Observable<string> {
    return this.httpClient.post<string>(`${environment.API_URL}account/login`, { Email: loginModel.email, Password: loginModel.password });
  }

  logout() {
    localStorage.removeItem('accessToken');
    this.currentUser = null;
  }
}
