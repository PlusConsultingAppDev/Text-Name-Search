import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import 'rxjs/add/operator/map';
import { getToken, IS_BUILD_VERSION } from '@iframework/core';
import { getApiUrl } from '@iframework/config';
import { ObservableHttp } from './observable-http';
import { getRequest, mapResponse, getRequestOptions } from './request-utils';
import { getGeoLocation } from './http-utils';
var HttpService = (function () {
    function HttpService(http, router) {
        this.http = http;
        this.router = router;
        this._options = getRequestOptions();
    }
    HttpService.prototype.postByRequest = function (request, endPoint, requestDetails) {
        if (!request.request.requestDetails) {
            request.request.requestDetails = requestDetails;
        }
        var observable = mapResponse(this.http.post(getApiUrl() + endPoint, JSON.stringify(request), this._options));
        return new ObservableHttp(observable, this.router);
    };
    HttpService.prototype.post = function (endPoint, requestDetails) {
        var request = getRequest("token", "", "", getToken(), requestDetails);
        return this.postByRequest(request, endPoint, requestDetails);
    };
    HttpService.prototype.get = function (url, options, json) {
        if (json === void 0) { json = true; }
        if (json) {
            return this.http.get(url + "?v=" + IS_BUILD_VERSION, options);
        }
        else {
            return this.http.get(url, options);
        }
    };
    HttpService.prototype.getGeoLocation = function () {
        return getGeoLocation(this.http);
    };
    HttpService.decorators = [
        { type: Injectable },
    ];
    HttpService.ctorParameters = function () { return [
        { type: HttpClient, },
        { type: Router, },
    ]; };
    return HttpService;
}());
export { HttpService };
//# sourceMappingURL=http.service.js.map