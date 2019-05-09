import { Component, OnInit } from '@angular/core';
import { ProfileService } from 'src/app/services';
import { User } from 'src/app/models';
import { MatDialog } from '@angular/material/dialog';
import { ConfirmCodeComponent } from './confirm-code/confirm-code.component';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  user: User;

  constructor(private profileService: ProfileService, private dialog: MatDialog) { }

  ngOnInit() {
    this.profileService.getUser().subscribe(user => {
      this.user = user;
    });
  }

  confirmEmail() {
    this.profileService.cofnirmEmail().subscribe(response => {
      const dialogRef = this.dialog.open(ConfirmCodeComponent, {
        width: '250px',
        data: true
      });

      dialogRef.afterClosed().subscribe(result => {
        this.profileService.getUser().subscribe(user => {
          this.user = user;
        });
      });
    })
  }

  confirmNumber() {
    this.profileService.confirmNumber().subscribe(response => {
      const dialogRef = this.dialog.open(ConfirmCodeComponent, {
        width: '250px',
        data: false
      });

      dialogRef.afterClosed().subscribe(result => {
        this.profileService.getUser().subscribe(user => {
          this.user = user;
        });
      });
    })
  }

  changeEmailNotification() {
    this.profileService.changeEmailNotification().subscribe(response => {
      this.profileService.getUser().subscribe(user => {
        this.user = user;
      });
    });
  }

  changeSmsNotification() {
    this.profileService.changeSmsNotification().subscribe(response => {
      this.profileService.getUser().subscribe(user => {
        this.user = user;
      });
    });
  }
}
