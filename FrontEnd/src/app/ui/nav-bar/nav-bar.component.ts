import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from 'src/app/core/models/user';
import { AuthService } from 'src/app/core/services/auth.service';
import { SharedService } from 'src/app/core/services/shared.service';
import { TokenStorageService } from 'src/app/core/services/token-storage.service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {
  loggedIn:boolean=false;
  userName: string;
  user: User;
  currentRoute: string="";


  constructor(private tokenService: TokenStorageService, private authService:AuthService,
              private router: Router,
              private route:ActivatedRoute, 
              private sharedService: SharedService ) { 
    this.user = this.tokenService.getUser();
    this.userName = 'unknown user';

    this.sharedService.booleanData$.subscribe((data) => {
      this.loggedIn = data;
      console.log(this.loggedIn); 
    });

    this.sharedService.userName$.subscribe((data) => {
      this.userName = data;
      console.log(this.userName); 
    });
    
  }

  ngOnInit(): void {
    this.currentRoute = this.router.url;
    console.log(this.currentRoute);
    this.user = this.tokenService.getUser();
    if (this.user?.firstName) {
      this.userName = `${this.user?.firstName} ${this.user?.lastName}`; 
      this.sharedService.updateBooleanData(true); 
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
    this.loggedIn = false;
   this.router.navigate(['/login']);
   this.sharedService.updateUserName('');
    
  }

  

  GotoCategories(){
    console.log("Inside Goto Categories");
    this.router.navigate(['site/category']);

  }

  GotoPriorities(){
    console.log("Inside Goto Priorities");
    this.router.navigate(['site/priority']);
  }

  GotoUsers(){
    console.log("Inside Goto Users");
    this.router.navigate(['site/user']);
  }

  GotoToDos(){
    console.log("Inside Goto Todos");
    this.router.navigate(['site/todo']);
  }

}
