import { Component } from '@angular/core';
import { User } from 'src/app/core/models/models';
import { AlertService } from 'src/app/core/services/alert.service';
import { AuthService } from 'src/app/core/services/auth.service';
import { TokenStorageService } from 'src/app/core/services/token-storage.service';
import { UserService } from 'src/app/core/services/user.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent {
  model = new User();

  isRegistered = false;
  isRegisterFailed = false;
  errorMessage = '';

  constructor(
    private userService: UserService,
    private tokenStorage: TokenStorageService,
    private alertService: AlertService
  ) {}

  ngOnInit(): void {
    this.isRegistered = false;
  }

  onSubmit(): void {
    this.userService.create(this.model).subscribe({
      next: (data) => {
        this.tokenStorage.saveUser(data);

        this.isRegisterFailed = false;
        this.isRegistered = true;
      },
      error: (error) => {
        this.alertService.error(error.error);
        this.isRegisterFailed = true;
      },
    });
  }
}
