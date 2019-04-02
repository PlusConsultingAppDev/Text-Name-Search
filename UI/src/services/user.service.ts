import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { UserModel } from '../models/UserModel';

@Injectable()
export class UserService {
  private url = 'http://localhost:51368/api/User';

  constructor(private httpClient: HttpClient) {}

  authenticate(user: UserModel): Observable<UserModel> {
    return this.httpClient.post<UserModel>(this.url, user);
  }
}
