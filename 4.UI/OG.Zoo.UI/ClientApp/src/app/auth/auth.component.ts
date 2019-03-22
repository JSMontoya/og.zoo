import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { AuthService } from './services/auth.service';
import { untilComponentDestroyed } from '@w11k/ngx-componentdestroyed';
import { MatSnackBar } from '@angular/material';
import { Route, Router } from '@angular/router';
import { Base64 } from '../shared/utils/base64';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.scss']
})
export class AuthComponent implements OnInit, OnDestroy {
  authForm = this.fb.group({
    name: [null, Validators.required],
    password: [null, Validators.required]
  });
  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private snackBar: MatSnackBar,
    private router: Router) { }

  ngOnInit() {
  }

  onSubmit() {
    if (this.authForm.valid) {
        const user = this.authForm.value;
        user.password = Base64.encode(user.password);
        this.authService.authenticate(user).pipe(untilComponentDestroyed(this)).subscribe(() => {
          this.snackBar.open(`User "${user.name}" has logged on.`, 'Dismiss', { duration: 3000});
          this.router.navigate(['home']);
        });
    }
  }

  ngOnDestroy(): void {}

}
