import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { HttpService } from './http.service';
var HttpServiceModule = (function () {
    function HttpServiceModule() {
    }
    HttpServiceModule.forRoot = function () { return { ngModule: HttpServiceModule }; };
    HttpServiceModule.decorators = [
        { type: NgModule, args: [{
                    imports: [HttpClientModule],
                    providers: [HttpService]
                },] },
    ];
    return HttpServiceModule;
}());
export { HttpServiceModule };
//# sourceMappingURL=http-service.module.js.map