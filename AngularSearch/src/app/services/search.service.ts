import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { IName } from '../models/iname';
import { ISearchResult } from '../models/isearch-result';

@Injectable({
  providedIn: 'root'
})
export class SearchService {

  searchItems: IName[];

  constructor(private http: HttpClient) { }

  public getSearchItems(): Observable<IName[]> {
    return this.http.get<IName[]>(`${environment.apiUrl}searchItems`);
  }
  public getSearchItem(searchItemId: number): Observable<IName>  {
    return this.http.get<IName>(`${environment.apiUrl}searchItems/${searchItemId}`);
  }
  public addSearchItem(searchItem: IName): Observable<IName> {
    return this.http.post<IName>(`${environment.apiUrl}searchItems`, searchItem);
  }
  public deleteSearchItem(searchItemId: number): Observable<IName> {
    return this.http.delete<IName>(`${environment.apiUrl}searchItems/${searchItemId}`);
  }

   public search(article: string): Observable<ISearchResult[]> {
    const results: ISearchResult[] = [];
    for (const item of this.searchItems) {
      const regEx = new RegExp(`(${item.firstName} ${item.lastName})|(${item.firstName} ${item.middleName.substring(0, 1)} ${item.lastName})|(${item.firstName} ${item.middleName.substring(0, 1)}\. ${item.lastName})|(${item.firstName} ${item.middleName} ${item.lastName})`, 'gi');
      results.push({
        name: item,
        count: (article.match(regEx) || []).length
      });
    }

    return of(results);
   }

}
