import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Category } from '../models/category';
import { MessageService } from './message.service';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  private categoryUrl = 'site/category' //URL to view category
  constructor(private http: HttpClient) {}


  getCategory(): Observable<Category[]> {
    return this.http.get<Category[]>(this.categoryUrl).pipe(
      retry(2),
      catchError((error: HttpErrorResponse) => {
        console.error(error);
        return throwError(error);
      })
    );
  }


//   httpOptions = {
//     headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
//   };


//   constructor(
//     private http: HttpClient,
//     private messageService: MessageService
//   ) { }

//    /** GET Categories list from in-memory [This will be updated once we have BACKEND SERVER is ready] **/ 
// getCategory() :Observable<Category[]>{
//   return this.http.get<Category[]>(this.categoryUrl).pipe(
//     tap((_) => this.log("fetched Category")),
//     catchError(this.handleError<Category[]>('getCategory', []))
//   );

// }

//   /**
//    * Handle Http operation that failed.
//    * Let the app continue.
//    *
//    * @param operation - name of the operation that failed
//    * @param result - optional value to return as the observable result
//    */
//    private handleError<T>(operation = 'operation', result?: T) {
//     return (error: any): Observable<T> => {
//       // TODO: send the error to remote logging infrastructure
//       console.error(error); // log to console instead

//       // TODO: better job of transforming error for user consumption
//       this.log(`${operation} failed: ${error.message}`);

//       // Let the app keep running by returning an empty result.
//       return of(result as T);
//     };
//   }

//   /** Log a CategoryService message with the MessageService */
// private log(message: string) {
//   this.messageService.add(`CategoryService: ${message}`);
// }

}
