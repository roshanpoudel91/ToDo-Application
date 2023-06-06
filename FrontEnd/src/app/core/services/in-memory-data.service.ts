import { Injectable } from '@angular/core';
import { InMemoryDbService } from 'angular-in-memory-web-api';

@Injectable({
  providedIn: 'root'
})
export class InMemoryDataService implements InMemoryDbService {

  constructor() { }

  createDb() {

    const categories = [
      { id: 1, name: 'Dr. Nice', date: '2022-10-15', description:"Dr. Nice" },
      { id: 2, name: 'Bombasto', date: '2023-10-16', description:"Bombasto" },
      { id: 3, name: 'Celeritas', date: '2023-10-18', description:"Celeritas"  },
      { id: 4, name: 'Magneta', date: '2022-10-20', description:"Magneta"  },
      { id: 5, name: 'RubberMan', date: '2022-10-25', description:"RubberMan" },
      { id: 6, name: 'Dynama', date: '2023-10-28', description:"Dynama"  },
      { id: 7, name: 'Dr. IQ', date: '2021-10-30', description:"Dr. IQ"  },
      { id: 8, name: 'Magma', date: '2020-10-15', description:"Magma"  },
      { id: 9, name: 'Tornado', date: '2020-10-01', description:"Tornado"  },
      { id: 10, name: 'Rock', date: '2020-10-05', description:"Rock"  },
      // { categoryId: 20, name: 'Edmonton', date: '2020-10-06', description:"Edmonton"  },
    ];

  return {categories};

  }

  
}
