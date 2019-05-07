import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { RegisterModel } from 'src/app/models';
import { Router, ActivatedRoute } from '@angular/router';
import { UserService } from 'src/app/services';
import { first } from 'rxjs/operators';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  hidePassword = true;
  hideConfirmPassword = true;

  registerModel = new RegisterModel();

  returnUrl: string;

  emailField = new FormControl(this.registerModel.email, [Validators.email, Validators.required]);
  passwordField = new FormControl(this.registerModel.password, [Validators.minLength(6), Validators.required]);
  confirmPasswordField = new FormControl(this.registerModel.confirmPassword, [Validators.minLength(6), Validators.required]);
  userNameField = new FormControl(this.registerModel.userName, [Validators.required, Validators.minLength(3)]);
  phoneNumberField = new FormControl(this.registerModel.phoneNumber, [Validators.required, Validators.minLength(12)]);

  constructor(private router: Router, private route: ActivatedRoute,
    private userService: UserService, private snackBar: MatSnackBar) { }

  ngOnInit() {
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/dashboard';
  }

  register() {
    if (this.passwordField.value !== this.confirmPasswordField.value) {
      this.passwordField.setErrors({});
      this.confirmPasswordField.setErrors({});
      return;
    }

    var registerModel = new RegisterModel();
    registerModel.email = this.emailField.value;
    registerModel.password = this.passwordField.value;
    registerModel.confirmPassword = this.confirmPasswordField.value;
    registerModel.userName = this.userNameField.value;
    registerModel.phoneNumber = this.phoneNumberField.value;

    this.userService.register(registerModel)
      .subscribe(
        token => {
          if (token) {
            localStorage.setItem('accessToken', JSON.stringify(token));
            this.router.navigate([this.returnUrl]);
          }
        },
        error => {
          this.snackBar.open("Користувач з такою електронною поштою вже існує", "Закрити", {
            duration: 3000
          });
        });
  }

  getEmailErrorMessage() {
    return this.emailField.hasError('required') ? 'Введіть електронну адресу' :
      this.emailField.hasError('email') ? 'Електронна адреса невалідна' :
        '';
  }

  getPasswordErrorMessage() {
    return this.passwordField.hasError('required') ? 'Введіть пароль' :
      this.passwordField.hasError('minlength') ? 'Мінімальна довжина пароля 6 символів' : "Паролі повинні співпадати";
  }

  getConfirmPasswordErrorMessage() {
    return this.confirmPasswordField.hasError('required') ? 'Підтвердіть пароль' :
      this.confirmPasswordField.hasError('minlength') ? 'Мінімальна довжина пароля 6 символів' : "Паролі повинні співпадати";
  }

  getUserNameErrorMessage() {
    return this.userNameField.hasError('required') ? "Введіть ім'я користувача" : 'Мінімальна довжина імені 3 символи';
  }

  getPhoneNumberErrorMessage() {
    return this.phoneNumberField.hasError('required') ? "Введіть номер телефону" : 'Мінімальна довжина номеру 12 символи';
  }

  isFormValid() {
    return this.emailField.valid
      && this.passwordField.valid
      && this.confirmPasswordField.valid
      && this.userNameField.valid
      && this.phoneNumberField.valid;
  }
}
