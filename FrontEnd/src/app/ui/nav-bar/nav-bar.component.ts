import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/core/models/user';
import { TokenStorageService } from 'src/app/core/services/token-storage.service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {

  userName: string;
  user: User;
  
  constructor(private tokenService: TokenStorageService ) { 
    this.user = this.tokenService.getUser();
    this.userName = 'unknown user'
  }

  ngOnInit(): void {
    this.user = this.tokenService.getUser();
    if (this.user?.firstName) {
      this.userName = `${this.user?.firstName} ${this.user?.lastName}`;  
    } else {
      this.userName = '';
    }  
  }

}
