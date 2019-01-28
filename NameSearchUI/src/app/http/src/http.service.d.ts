import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import { ObservableHttp } from './observable-http';
import { RequestJSON, RequestOptions, GeoLocationItem } from './models';
export declare class HttpService {
    private http;
    private router;
    private _options;
    constructor(http: HttpClient, router: Router);
    postByRequest(request: RequestJSON, endPoint: string, requestDetails: Object): ObservableHttp;
    post(endPoint: string, requestDetails: Object): ObservableHttp;
    get(url: string, options?: RequestOptions, json?: boolean): Observable<any>;
    getGeoLocation(): Observable<GeoLocationItem>;
}
