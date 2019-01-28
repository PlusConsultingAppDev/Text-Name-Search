import { HttpHeaders } from '@angular/common/http';
export interface RequestJSON {
    request: RequestItem;
}
export interface RequestHeader {
    type: string;
    username: string;
    password: string;
    token: string;
    portal: number;
    vRoot?: string;
}
export interface RequestItem {
    header: RequestHeader;
    requestDetails: any;
}
export interface ResponseJSON {
    response: ResponseItem;
}
export interface ResponseHeader {
    status: number;
    message: string;
    token: string;
}
export interface ResponseItem {
    header: ResponseHeader;
    responseDetails: Object;
}
export interface RequestOptions {
    headers: HttpHeaders;
}
export interface GeoLocationItem {
    ip: string;
    city: string;
    countryName: string;
    countryCode: string;
    regionName: string;
    regionCode: string;
    zipcode: string;
    timeZone: string;
    latitude: number;
    longitude: number;
}
