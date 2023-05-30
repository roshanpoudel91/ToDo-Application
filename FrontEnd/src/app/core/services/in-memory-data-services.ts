import { Injectable } from '@angular/core';
import { InMemoryDbService, RequestInfo } from 'angular-in-memory-web-api';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class InMemoryDataService implements InMemoryDbService {
  constructor() { }
  createDb() {
    const categories = [
        { CategoryID: 1, name: 'Dr. Nice' , Date: '' , Description: '' , created_at: '' , updated_at: '' , deleted_at: ''},
     
      ];
return {categories};
}
}