import { Injectable } from '@angular/core';
import {InMemoryDbService} from 'angular-in-memory-web-api';
import { IName } from '../models/iname';

@Injectable({
  providedIn: 'root'
})
export class DataAPIService implements InMemoryDbService {

  constructor() { }

  createDb() {

    const searchItems = [
      {id: 1, firstName: 'Connor', middleName: 'Gary', lastName: 'Smith'},
      {id: 2, firstName: 'Seth', middleName: 'David', lastName: 'Greenly'},
      {id: 3, firstName: 'David', middleName: 'Warren', lastName: 'Black'}
    ];

    return {searchItems};
  }
  genId(names: IName[]): number {
    return names.length > 0 ? Math.max(...names.map(item => item.id)) + 1 : 11;
  }
}
