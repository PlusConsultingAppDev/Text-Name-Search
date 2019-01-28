import { ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { GeoLocationItem } from './models';
export declare function getUrl(route: ActivatedRoute): string;
export declare function getGeoLocation(http: HttpClient): Observable<GeoLocationItem>;
export declare function getVRoot(): string;
export declare function setVRoot(vRoot: string): void;
export declare function clearVRoot(): void;
