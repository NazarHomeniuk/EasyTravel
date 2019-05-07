import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
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

  registerForm: FormGroup;
  registerModel = new RegisterModel();

  returnUrl: string;
  
  constructor( private formBuilder: FormBuilder, private router: Router, 
    private route: ActivatedRoute, private userService: UserService, private snackBar: MatSnackBar) { }

  ngOnInit() {
    this.registerForm = this.formBuilder.group({
      email: [this.registerModel.email, [Validators.required, Validators.email]],
      password: [this.registerModel.password, [Validators.required, Validators.minLength(6)]],
      confirmPassword: [this.registerModel.confirmPassword, [Validators.required, Validators.minLength(6)]],
      userName: [this.registerModel.userName, Validators.required, Validators.minLength(3)],
      phoneNumber: [this.registerModel.phoneNumber, Validators.required, Validators.minLength(12)]
    });
    
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/dashboard';
  }

  register() {
    this.userService.register(this.registerModel)
      .pipe(first())
      .subscribe(
        data => {
          this.router.navigate([this.returnUrl]);
        },
        error => {
          this.snackBar.open(error, "Закрити", {
            duration: 3000
          });
        });
  }
}
