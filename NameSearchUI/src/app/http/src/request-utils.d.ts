import { Observable } from 'rxjs/Observable';
import { RequestJSON, RequestOptions } from './models';
export declare function getRequest(type: string, userName: string, password: string, token: string, requestDetails: Object): RequestJSON;
export declare function mapResponse(response: Observable<any>): Observable<any>;
export declare function getRequestOptions(): RequestOptions;
