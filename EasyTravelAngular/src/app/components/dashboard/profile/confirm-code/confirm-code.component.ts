import { Component, OnInit, Inject } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ProfileService } from 'src/app/services';

@Component({
  selector: 'app-confirm-code',
  templateUrl: './confirm-code.component.html',
  styleUrls: ['./confirm-code.component.css']
})
export class ConfirmCodeComponent implements OnInit {

  codeInput = new FormControl('', Validators.required);

  constructor(public dialogRef: MatDialogRef<ConfirmCodeComponent>,
    @Inject(MAT_DIALOG_DATA) public data: boolean,
    private profileService: ProfileService) { }

  ngOnInit() {
  }

  verify() {
    var code = this.codeInput.value;
    if (this.data) {
      this.profileService.confirmEmailCode(code).subscribe(result => {
        if (result == true) {
          this.dialogRef.close();
        }
        else {

        }
      })
    }
    else {
      this.profileService.confirmNumberCode(code).subscribe(result => {
        if (result == true) {
          this.dialogRef.close();
        }
        else {

        }
      });
    }
  }
}
