import { Component, Inject, Input, ViewChild, ElementRef } from '@angular/core';
import { ManageComponent } from './manage.component';
var ManageToolbarComponent = (function () {
    function ManageToolbarComponent(_parent) {
        this._parent = _parent;
        this.visibleColumns = [];
        this.columns = [];
        this.hideFilter = true;
    }
    ManageToolbarComponent.prototype.ngOnInit = function () {
        this.isMobile = window.isMobile();
    };
    ManageToolbarComponent.prototype.ngAfterViewInit = function () {
        this._el = this.filter.nativeElement;
    };
    ManageToolbarComponent.prototype.ngOnChanges = function (changes) {
        if (changes["actionItems"]) {
            this.hasActions = !Array.isEmpty(this.actionItems);
        }
        if (changes["columns"] && changes["columns"].currentValue) {
            this.columns.sort(function (x, y) {
                if (x.headerName > y.headerName) {
                    return 1;
                }
                else if (x.headerName < y.headerName) {
                    return -1;
                }
                else {
                    return 0;
                }
            });
        }
    };
    ManageToolbarComponent.prototype.openDual = function () {
        if (this.columns.length > 15) {
            this._parent.columnsmodal.show();
        }
    };
    ManageToolbarComponent.prototype.toggleSearch = function () {
        var _this = this;
        this.hideFilter = !this.hideFilter;
        this.filter.nativeElement.value = "";
        if (!this.hideFilter) {
            setTimeout(function () { _this._el.focus(); }, 5);
        }
    };
    ManageToolbarComponent.prototype.addRow = function () {
        this._parent.addRows();
    };
    ManageToolbarComponent.prototype.csvExport = function () {
        var params = {
            skipHeader: false, skipFooters: false, skipGroups: false, allColumns: false, onlySelected: false, fileName: "export.csv", columnSeparator: ",",
            processCellCallback: function (params) {
                if (params.column.colDef.fileName != "") {
                    if (params.column.colDef.cellRenderer) {
                        return params.column.colDef.cellRenderer(params);
                    }
                    else {
                        return params.value;
                    }
                }
                else {
                    return null;
                }
            }
        };
        this._parent.gridOptions.api && this._parent.gridOptions.api.exportDataAsCsv(params);
    };
    ManageToolbarComponent.prototype.clearFilter = function () {
        this._parent.get();
    };
    ManageToolbarComponent.prototype.sizeToFit = function () { this._parent.sizeToFit(); };
    ManageToolbarComponent.prototype.setColumnVisibility = function (e, columnHeader) {
        e.stopImmediatePropagation();
        e.stopPropagation();
        e.preventDefault();
        var state = this._parent.gridOptions.columnApi && this._parent.gridOptions.columnApi.getColumnState().find(function (x) { return x.colId == columnHeader; });
        this._parent.gridOptions.columnApi && this._parent.gridOptions.columnApi.setColumnVisible(columnHeader, state.hide);
        this._parent.updateColumnVisibility();
        this.sizeToFit();
    };
    ManageToolbarComponent.prototype.onFilterChanged = function (e) { this._parent.gridOptions.api && this._parent.gridOptions.api.setQuickFilter(e.target.value); };
    ManageToolbarComponent.decorators = [
        { type: Component, args: [{
                    selector: 'is-managetoolbar',
                    template: "\n    <div *ngIf=\"!isMobile\" class=\"row\">\n        <div class=\"col-12 actions-header\">\n            <div *ngIf=\"title\" class=\"pull-left\"><h4 [innerHTML]=\"title\"></h4></div>\n            <div class=\"pull-right\">\n                <div class=\"btn-group\" role=\"toolbar\">\n                    <button type=\"button\" class=\"btn btn-toolbar\" (click)=\"toggleSearch()\"><i class=\"fa fa-search\" aria-hidden=\"true\"></i></button>\n                    <a *ngIf=\"gridAction\" class=\"btn btn-toolbar\" (click)=\"addRow()\"><i class=\"fa fa-plus\" aria-hidden=\"true\"></i></a>\n                    <a *ngIf=\"!actionItems && addRoute\" class=\"btn btn-toolbar\" [routerLink]=\"[addRoute]\"><i class=\"fa fa-plus\" aria-hidden=\"true\"></i></a>\n                    <div *ngIf=\"actionItems\"  class=\"btn-group\">\n                        <button type=\"button\" class=\"btn-group dropdown-toggle btn btn-toolbar dropdown\" data-toggle=\"dropdown\" aria-haspopup=\"true\" aria-expanded=\"false\">\n                            <i [ngClass]=\"{'fa': true, 'fa-plus': !hasActions, 'fa-tasks': hasActions}\" aria-hidden=\"true\"></i>\n                            <span class=\"caret\"></span>\n                        </button>\n                        <ul class=\"dropdown-menu dropdown-menu-right\">\n                            <li *ngFor=\"let action of actionItems\"><a class=\"clickable\" (click)=\"action.click($event)\">{{ action.label }}</a></li>\n                        </ul> \n                    </div>\n                    <div class=\"btn-group\">\n                        <button type=\"button\" class=\"btn btn-toolbar dropdown-toggle\" data-toggle=\"dropdown\" aria-haspopup=\"true\" aria-expanded=\"false\">\n                            <i class=\"fa fa-cog\" aria-hidden=\"true\"></i>\n                            <span class=\"caret\"></span>\n                        </button>\n                        <ul class=\"dropdown-menu dropdown-menu-right\">\n                            <li><a class=\"clickable\" (click)=\"csvExport()\">Export to CSV</a></li>\n                            <li role=\"separator\" class=\"divider\"></li>\n                            <li class=\"clickable\"><a (click)=\"sizeToFit()\">Size to Fit</a></li>\n                            <li role=\"separator\" class=\"divider\"></li>\n                            <li class=\"clickable\"><a (click)=\"clearFilter()\">Clear All Filters</a></li>\n                            <li role=\"separator\" class=\"divider\"></li>\n                            <li  class=\"clickable\"><a (click)=\"openDual()\"><b>Customize Columns</b></a></li>\n                            <ng-template ngFor let-column [ngForOf]=\"columns\">\n                                <li *ngIf=\"columns.length <= 15 && column.headerName != ''\"><a>\n                                <div><is-checkbox (click)=\"setColumnVisibility($event, column.field)\" layout=\"vertical\" [value]=\"column.field\" [(ngModel)]=\"visibleColumns\">{{ column.headerName }}</is-checkbox></div>\n                                </a></li>\n                            </ng-template>\n                        </ul>\n                    </div>\n                </div>\n            </div>\n            <div class=\"pull-right\" [ngStyle]=\"{'padding-right':'10px', 'visibility': hideFilter ? 'hidden' : 'visible'}\">\n                <input #filter type=\"text\" class=\"form-control\" placeholder=\"Filter results\" (input)=\"onFilterChanged($event)\">\n            </div>\n        </div>\n    </div>\n\t<div *ngIf=\"isMobile\" class=\"row\">\n        <div class=\"col-12 actions-header\">\n            <div class=\"pull-right\">\n                <div class=\"btn-group\" role=\"toolbar\">\n                    <a class=\"btn btn-toolbar\" [routerLink]=\"[addRoute]\"><i class=\"fa fa-plus\" aria-hidden=\"true\"></i></a>\n                </div>\n            </div>\n            <div class=\"pull-right\" style=\"padding-right:10px\">\n                <input #filter type=\"text\" class=\"form-control\" placeholder=\"Filter results\" (input)=\"onFilterChanged($event)\">\n            </div>\n        </div>\n    </div>\n\t",
                    exportAs: 'isManageToolbar'
                },] },
    ];
    ManageToolbarComponent.ctorParameters = function () { return [
        { type: ManageComponent, decorators: [{ type: Inject, args: [ManageComponent,] },] },
    ]; };
    ManageToolbarComponent.propDecorators = {
        "actionItems": [{ type: Input },],
        "id": [{ type: Input },],
        "addRoute": [{ type: Input },],
        "gridAction": [{ type: Input },],
        "visibleColumns": [{ type: Input },],
        "columns": [{ type: Input },],
        "title": [{ type: Input },],
        "filter": [{ type: ViewChild, args: ['filter',] },],
    };
    return ManageToolbarComponent;
}());
export { ManageToolbarComponent };
//# sourceMappingURL=manage-toolbar.component.js.map