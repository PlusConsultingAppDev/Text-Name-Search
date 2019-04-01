"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var shell_module_1 = require("./shell.module");
describe('ShellModule', function () {
    var shellModule;
    beforeEach(function () {
        shellModule = new shell_module_1.ShellModule();
    });
    it('should create an instance', function () {
        expect(shellModule).toBeTruthy();
    });
});
//# sourceMappingURL=shell.module.spec.js.map