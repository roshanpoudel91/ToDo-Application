import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { User } from 'src/app/core/models/models';
import { AlertService } from 'src/app/core/services/alert.service';
import { AuthService } from 'src/app/core/services/auth.service';
import { TokenStorageService } from 'src/app/core/services/token-storage.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent {
  model = new User();
  submitted = false;

  isLoggedIn = false;
  isLoginFailed = false;
  userName = "Unknown User";
  //roles: string[] = [];

  constructor(
    private authService: AuthService,
    private router: Router,
    private tokenStorage: TokenStorageService,
    private alertService: AlertService
  ) {}

  ngOnInit(): void {
    if (this.tokenStorage.getToken()) {
      this.isLoggedIn = true;
      this.model = this.tokenStorage.getUser();
      this.userName = `${this.model?.firstName} ${this.model?.lastName}`; 
      //this.roles = this.tokenStorage.getUser().roles;
    }
  }

  onSubmit(): void {
    this.submitted = true;
    this.authService.login(this.model).subscribe({
      next: (data) => {
        this.tokenStorage.saveToken(data.accessToken ?? '');
        this.tokenStorage.saveUser(data);

        this.isLoginFailed = false;
        this.isLoggedIn = true;
        
        this.router.navigate(['/site/home']);
      },
      error: (error) => {
        this.router.navigate(['/site/home']);
        console.log('hhhh');
        this.alertService.error(error.error);               
        this.isLoginFailed = true;
        this.submitted = false;
      },
    });
  }

  reloadPage(): void {
    window.location.reload();
  }
}
