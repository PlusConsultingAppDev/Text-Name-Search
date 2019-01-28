import { Injectable } from '@angular/core';
import { ManageComponent, ManageService } from '../manage';
import { HttpService } from '../http';
import 'rxjs/add/operator/map';
import { Observable } from 'rxjs/Observable';
import { Subscriber } from 'rxjs/Subscriber';

@Injectable()

export class SearchService extends ManageService {

    private endpoint : string;

    constructor(private http: HttpService) {
		super(true);
		this.endpoint = "Search";
		this.rowActions = [];
    }
    
    public searchNames(firstName: string, middleInitial: string, lastName: string) {
        let request = {
            searchItem : {
                firstName : firstName, middleInitial : middleInitial, lastName : lastName
            }
        }
        return this.http.post(this.endpoint + "/SearchNames", request);
    }

    public get(requestsearchcriteria: any) {
		return Observable.create((observer: Subscriber<any>) => {
            observer.next([]);
            observer.complete();
        });
	}
    public getById() { }
	public add() { }
	public delete() { }
	public update() { }
}