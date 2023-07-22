import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MessageService } from './message.service';
import { Observable, catchError, of, tap } from 'rxjs';
import { Priority } from '../models/Priority';

@Injectable({
  providedIn: 'root'
})
export class PriorityService { 

  //private priorityUrl = 'api/priorities'; // URL to web api
  private priorityUrl = 'https://localhost:7215/api/priority/priority'; // URL to web api

  // httpOptions = {
  //   headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
  // };

  constructor(
    private http: HttpClient,
    private messageService: MessageService
  ) {}

  /** GET priorities from the server */
  getPriorities(): Observable<Priority[]> {
    return this.http.get<Priority[]>(this.priorityUrl).pipe(
      tap((_) => this.log('fetched priorities')),
      catchError(this.handleError<Priority[]>('getPriorities', []))
    );
  }


  /** GET priority by priorityId. Will 404 if priorityId not found */
  getPriority(priorityId: number): Observable<Priority> {
    const url = `${this.priorityUrl}/${priorityId}`;
    console.log(url);
    return this.http.get<Priority>(url).pipe(
      tap(_ => this.log(`fetched priority priorityId=${priorityId}`)),
      catchError(this.handleError<Priority>(`getCategory priorityId=${priorityId}`))
    );
  }

   /** PUT: update the priority on the server */
   // don't forget to add httoptions after integrating real API
   updatePriority(priority: Priority): Observable<any> {
    const url = `${this.priorityUrl}/${priority.priorityId}`;
    return this.http.put(url, priority).pipe(
      tap(_ => this.log(`updated priority priorityId=${priority.priorityId}`)),
      catchError(this.handleError<any>('updatePriority'))
    );
  }

  deletePriority(priorityId: number): Observable<any> {
    const url = `${this.priorityUrl}/${priorityId}`;
    return this.http.delete(url).pipe(
      tap(_ => console.log(`Deleted priority with priorityId=${priorityId}`)),
      catchError(this.handleError<any>('deletePriority'))
    );
  }
  
  /** DELETE: delete the person from the server */
  // deletePerson(priorityId: number): Observable<Person> {
  //   const url = `${this.personsUrl}/${priorityId}`;

  //   return this.http.delete<Person>(url, this.httpOptions).pipe(
  //     tap((_) => this.log(`deleted person priorityId=${priorityId}`)),
  //     catchError(this.handleError<Person>('deletePerson'))
  //   );
  // }

  /** POST: add a new person to the server */
  addPriority(priority: Priority): Observable<Priority> {
    
    return this.http
      .post<Priority>(this.priorityUrl, priority)
      .pipe(
        tap((newPriority: Priority) =>
          this.log(`added priority w/ priorityId=${newPriority.priorityId}`)
        ),
        catchError(this.handleError<Priority>('addPriority'))
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
    this.messageService.add(`PriorityService: ${message}`);
  }
}
