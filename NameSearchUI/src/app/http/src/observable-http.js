var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
import { Observable } from 'rxjs/Observable';
import { getToken, setToken, clearSessionParams } from '@iframework/core';
import { getSellerUrl, getPortal, getLogin, getChangePassword } from '@iframework/config';
import { ErrorHandler } from './error-handler';
import { getVRoot } from './http-utils';
var ObservableHttp = (function (_super) {
    __extends(ObservableHttp, _super);
    function ObservableHttp(observable, router) {
        var _this = _super.call(this) || this;
        _this.observable = observable;
        _this.router = router;
        return _this;
    }
    ObservableHttp.prototype.subscribe = function (observerOrNext, error, complete) {
        var _this = this;
        return this.observable.subscribe(function (res) {
            var header = res.header;
            if (header.status == 200) {
                if (header.token != getToken()) {
                    setToken(header.token);
                }
                if (observerOrNext) {
                    if (window.isFunction(observerOrNext)) {
                        observerOrNext(res.responseDetails);
                    }
                    else {
                        observerOrNext.next(res.responseDetails);
                    }
                }
            }
            else if (header.status == 403) {
                var portal = getPortal();
                var isLoginRoute = false;
                var vr_1 = "";
                _this.router.routerState.root.queryParamMap.forEach(function (next) {
                    vr_1 = next.get("_vr") || "";
                });
                var returnUrl = _this.router.routerState.snapshot.url;
                if (vr_1) {
                    returnUrl = returnUrl.replace("?_vr=" + vr_1, "").replace("&_vr=" + vr_1, "");
                }
                var queryParams = isLoginRoute ? null : { returnUrl: returnUrl };
                if (queryParams) {
                    if (vr_1) {
                        queryParams["_vr"] = vr_1;
                    }
                    else if (portal != 0) {
                        queryParams["_vr"] = getVRoot();
                    }
                }
                var login = getLogin();
                if (portal != 0) {
                    isLoginRoute = _this.router.url.toLowerCase().indexOf("/" + login) != -1;
                }
                if (!isLoginRoute) {
                    clearSessionParams();
                    if (portal != 0) {
                        _this.router.navigate([login], { queryParams: queryParams });
                    }
                    else {
                        window.location.href = getSellerUrl(login);
                    }
                }
                else if (error) {
                    error(res);
                }
            }
            else if (header.status == 417) {
                setToken(header.token);
                _this.router.navigate([getChangePassword()]);
            }
            else if (ErrorHandler.handleError) {
                ErrorHandler.handleError(res, error);
            }
            else if (error) {
                error(res);
            }
            else {
                console.log(res);
            }
        }, function (err) { return ErrorHandler.handleError(err); }, function () { return complete && complete(); });
    };
    return ObservableHttp;
}(Observable));
export { ObservableHttp };
//# sourceMappingURL=observable-http.js.map