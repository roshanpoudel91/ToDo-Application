import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from '../services/auth.service';
import { TokenStorageService } from '../services/token-storage.service';
import { UserService } from '../services/user.service';

@Injectable({
  providedIn: 'root'
})
export class CheckAdminGuard implements CanActivate {
   constructor(private userService: UserService,
    private authService: AuthService,
     private tokenStorageService: TokenStorageService,
     private router: Router){

   }
   result:boolean=true;
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot):
     Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
  
      return this.authService.getAdmin();
  
    }
  }
  

