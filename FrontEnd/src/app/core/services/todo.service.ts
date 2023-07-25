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

   /** GET person type by id. Will 404 if id not found */
   getTodo(id: number): Observable<ToDo> {
    const url = `${this.todoUrl}/${id}`;
    console.log(url);
    return this.http.get<ToDo>(url).pipe(
      tap(_ => this.log(`fetched todo id=${id}`)),
      catchError(this.handleError<ToDo>(`getTodo id=${id}`))
    );
  }

   /** PUT: update the person type on the server */
   // don't forget to add httoptions after integrating real API
   updateTodo(todo: ToDo): Observable<any> {
    const url = `${this.todoUrl}/${todo.todoId}`;
    console.log(url)
    return this.http.put(url, todo).pipe(
      tap(_ => this.log(`updated person type id=${todo.todoId}`)),
      catchError(this.handleError<any>('updateTodo'))
    );
  }
  deleteTodo(todoId: number): Observable<any> {
    const url = `${this.todoUrl}/${todoId}`;
    return this.http.delete(url).pipe(
      tap(_ => console.log(`Deleted todo with id=${todoId}`)),
      catchError(this.handleError<any>('deleteTodo'))
    );
  }
  /** DELETE: delete the person from the server */
  // deletePerson(id: number): Observable<Person> {
  //   const url = `${this.personsUrl}/${id}`;

  //   return this.http.delete<Person>(url, this.httpOptions).pipe(
  //     tap((_) => this.log(`deleted person id=${id}`)),
  //     catchError(this.handleError<Person>('deletePerson'))
  //   );
  // }

  /** POST: add a new person to the server */
  addTodo(todo: ToDo): Observable<ToDo> {
    
    return this.http
      .post<ToDo>(this.todoUrl, todo)
      .pipe(
        tap((newTodo: ToDo) =>
          this.log(`added todo w/ id=${newTodo.todoId}`)
        ),
        catchError(this.handleError<ToDo>('addTodo'))
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
