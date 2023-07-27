import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { User } from '../models/models';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private baseUrl;
  
  constructor(private httpClient:HttpClient) { 
    this.baseUrl = `${environment.baseUrl}/auth` 
  }

  public login(user: User) : Observable<User>
  {
    return this.httpClient.post<User>(`${this.baseUrl}/login` ,user, httpOptions);
  }

  public logout() : Observable<User>
  {
    return this.httpClient.post<User>(`${this.baseUrl}/logout`, httpOptions);
  }

  register(user: User): Observable<any> {
    return this.httpClient.post<User>(`${this.baseUrl}/register` ,user, httpOptions);
  }
}


