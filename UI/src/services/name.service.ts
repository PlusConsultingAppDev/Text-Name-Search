import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { NameModel } from '../models/NameModel';
import { AuthenticationService } from '../app/core/authentication/authentication.service';

@Injectable()
export class NameService {
  private nameUrl = 'http://localhost:51368/api/Name';

  constructor(private httpClient: HttpClient, private authenticationService: AuthenticationService) {}

  getNameAll(): Observable<NameModel[]> {
    return this.httpClient.get<NameModel[]>(this.nameUrl, {
      headers:
        new HttpHeaders().set('Authorization', 'Bearer ' + this.authenticationService.credentials)
          .set('Access-Control-Allow-Origin', '*')
    });
  }
  getNameById(options: any): Observable<NameModel> {
    return this.httpClient.get<NameModel>(this.nameUrl + '/' + options.nameId, {
      headers:
        new HttpHeaders().set('Authorization', 'Bearer ' + this.authenticationService.credentials)
          .set('Access-Control-Allow-Origin', '*')
    });
  }
  deleteNameById(id: string): Observable<{}> {
    return this.httpClient.delete(this.nameUrl + '/' + id, {
      headers:
        new HttpHeaders().set('Authorization', 'Bearer ' + this.authenticationService.credentials)
          .set('Access-Control-Allow-Origin', '*')
    });
  }
  saveName(name: NameModel): Observable<NameModel> {
    return this.httpClient.post<NameModel>(this.nameUrl, name, {
      headers:
        new HttpHeaders().set('Authorization', 'Bearer ' + this.authenticationService.credentials)
          .set('Access-Control-Allow-Origin', '*')
    });
  }
}
