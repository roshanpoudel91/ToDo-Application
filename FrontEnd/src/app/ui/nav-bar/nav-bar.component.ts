import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from 'src/app/core/models/user';
import { AuthService } from 'src/app/core/services/auth.service';
import { TokenStorageService } from 'src/app/core/services/token-storage.service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {

  userName: string;
  user: User;
  currentRoute: string="";
  
  constructor(private tokenService: TokenStorageService, private authService:AuthService,
              private router: Router,
              private route:ActivatedRoute ) { 
    this.user = this.tokenService.getUser();
    this.userName = 'unknown user';
    
  }

  ngOnInit(): void {
    this.currentRoute = this.router.url;
    console.log(this.currentRoute);
    this.user = this.tokenService.getUser();
    if (this.user?.firstName) {
      this.userName = `${this.user?.firstName} ${this.user?.lastName}`;  
    } else {
      this.userName = '';
    }  
  }

  logout(){
   this.tokenService.signOut();
  //  this.authService
  //  .logout()
  //  .subscribe((priorityResult) => {
  //    console.log(priorityResult);
  //  });

   this.router.navigate(['/login']);
 
    
  }

}
