import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MessageService } from './message.service';
import { Observable, catchError, of, tap } from 'rxjs';
import { Category } from '../models/category';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  private categoryUrl = 'https://localhost:7215/api/category/category'; // URL to web api

  // httpOptions = {
  //   headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
  // };

  constructor(
    private http: HttpClient,
    private messageService: MessageService
  ) {}

  /** GET categories from the server */
  getCategories(): Observable<Category[]> {
    return this.http.get<Category[]>(this.categoryUrl).pipe(
      tap((_) => this.log('fetched categories')),
      catchError(this.handleError<Category[]>('getCategories', []))
    );
  }


  /** GET person type by id. Will 404 if id not found */
  getCategory(id: number): Observable<Category> {
    const url = `${this.categoryUrl}/${id}`;
    console.log(url);
    return this.http.get<Category>(url).pipe(
      tap(_ => this.log(`fetched category id=${id}`)),
      catchError(this.handleError<Category>(`getCategory id=${id}`))
    );
  }

   /** PUT: update the person type on the server */
   // don't forget to add httoptions after integrating real API
   updateCategory(category: Category): Observable<any> {
    const url = `${this.categoryUrl}/${category.categoryId}`;
    console.log(url)
    return this.http.put(url, category).pipe(
      tap(_ => this.log(`updated person type id=${category.categoryId}`)),
      catchError(this.handleError<any>('updatePerson'))
    );
  }
  deleteCategory(categoryId: number): Observable<any> {
    const url = `${this.categoryUrl}/${categoryId}`;
    return this.http.delete(url).pipe(
      tap(_ => console.log(`Deleted category with id=${categoryId}`)),
      catchError(this.handleError<any>('deleteCategory'))
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
  addCategory(category: Category): Observable<Category> {
    
    return this.http
      .post<Category>(this.categoryUrl, category)
      .pipe(
        tap((newCategory: Category) =>
          this.log(`added category w/ id=${newCategory.categoryId}`)
        ),
        catchError(this.handleError<Category>('addCategory'))
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
    this.messageService.add(`CategoryService: ${message}`);
  }
}
