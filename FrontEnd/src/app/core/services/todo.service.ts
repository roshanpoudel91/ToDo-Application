import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ToDo } from '../models/todo';
import { Observable, catchError, of, tap } from 'rxjs';
import { MessageService } from './message.service';


@Injectable({
  providedIn: 'root'
})
export class TodoService {

  private todoUrl = 'https://localhost:7215/api/todo/todo'; // URL to web api

  constructor(
    private http: HttpClient,
    private messageService: MessageService
  ) { }

   /** GET priorities from the server */
   getTodos(): Observable<ToDo[]> {
    return this.http.get<ToDo[]>(this.todoUrl).pipe(
      tap((_) => this.log('fetched todo list')),
      catchError(this.handleError<ToDo[]>('getTodo', []))
    );
  }


   /**
   * Handle Http operation that failed.
   * Let the app continue.
   *
   * @param operation - name of the operation that failed
   * @param result - optional value to return as the observable result
   */
    private handleError<T>(operation = 'operation', result?: T) {
      return (error: any): Observable<T> => {
        // TODO: send the error to remote logging infrastructure
        console.error(error); // log to console instead
  
        // TODO: better job of transforming error for user consumption
        this.log(`${operation} failed: ${error.message}`);
  
        // Let the app keep running by returning an empty result.
        return of(result as T);
      };
    }
  
    /** Log a PersonService message with the MessageService */
    private log(message: string) {
      this.messageService.add(`ToDoService: ${message}`);
    }
}
