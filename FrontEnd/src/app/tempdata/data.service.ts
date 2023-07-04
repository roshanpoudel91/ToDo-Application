import { Injectable } from '@angular/core';
import { InMemoryDbService } from 'angular-in-memory-web-api';


@Injectable({
  providedIn: 'root'
})
export class DataService implements InMemoryDbService {

  constructor() { }
  createDb() {
    return {
      products: [
        {
          id: 1,
          name: 'Seaman Cap',
          description: 'Lorem ipsum . Voluptatem excepturi magnam nostrum dolore recusandae',
          price: '$40'
        }]}
}
}