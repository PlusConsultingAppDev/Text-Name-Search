import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { AgGridModule } from 'ag-grid-angular/dist/aggrid.module';
import { TranslatorModule } from '@iframework/translator';
import { ModalModule, ToastModule, CheckboxModule, DualModule } from '@iframework/forms';
import { ManageToolbarComponent } from './manage-toolbar.component';
import { ManageComponent } from './manage.component';
var EXPORTS = [ManageToolbarComponent, ManageComponent];
var ManageModule = (function () {
    function ManageModule() {
    }
    ManageModule.forRoot = function () { return { ngModule: ManageModule }; };
    ManageModule.decorators = [
        { type: NgModule, args: [{
                    imports: [CommonModule, FormsModule, RouterModule, AgGridModule.withComponents([]), TranslatorModule, ModalModule, ToastModule, CheckboxModule, DualModule],
                    declarations: EXPORTS,
                    exports: EXPORTS
                },] },
    ];
    return ManageModule;
}());
export { ManageModule };
//# sourceMappingURL=manage.module.js.map