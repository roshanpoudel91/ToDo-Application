import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SharedService {

  constructor() { }

  private isLoggedIn = new Subject<boolean>();

  booleanData$ = this.isLoggedIn.asObservable();

  updateBooleanData(data: boolean) {
    this.isLoggedIn.next(data);
  }

  private userName = new Subject<string>();

  userName$ = this.userName.asObservable();

  updateUserName(data: string) {
    this.userName.next(data);
  }


}
