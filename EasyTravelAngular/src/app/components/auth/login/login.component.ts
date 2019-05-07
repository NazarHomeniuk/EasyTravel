import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { LoginModel } from 'src/app/models';
import { UserService } from 'src/app/services';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { first } from 'rxjs/operators';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  hide = true;

  loginModel = new LoginModel();

  returnUrl: string;

  emailField = new FormControl(this.loginModel.email, [Validators.email, Validators.required]);
  passwordField = new FormControl(this.loginModel.password, [Validators.minLength(6), Validators.required]);

  constructor(private userService: UserService, private snackBar: MatSnackBar, 
    private route: ActivatedRoute, private router: Router) { }

  ngOnInit() {
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/dashboard';
  }

  login() {
    var loginModel = new LoginModel();
    loginModel.email = this.emailField.value;
    loginModel.password = this.passwordField.value;
    this.userService.login(loginModel).subscribe(token => {
      console.log(token);
      if (token) {
        console.log(token);
        localStorage.setItem('accessToken', JSON.stringify(token));
        this.router.navigate([this.returnUrl]);
      }
    });
  }

  getEmailErrorMessage() {
    return this.emailField.hasError('required') ? 'Введіть електронну адресу' :
      this.emailField.hasError('email') ? 'Електронна адреса невалідна' :
        '';
  }

  getPasswordErrorMessage() {
    return this.passwordField.hasError('required') ? 'Введіть пароль' : 'Мінімальна довжина пароля 6 символів';
  }

}
