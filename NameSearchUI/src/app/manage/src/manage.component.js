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
import { Component, Input, Output, EventEmitter, HostListener, ElementRef, HostBinding, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { TranslatorService } from '@iframework/translator';
import { FrameworkComponentBase, ModalService, ToastService, ModalComponent } from '@iframework/forms';
var RESULTS_FOUND = "\n    <div class=\"row\">\n        <div class=\"col-12\">\n            <label style=\"font-weight: 300;text-align:right;color: #a9a9a9;\">{{translator[\"RESULTFOUND\"]}}  {{this.totalSize}}</label>  \n        </div>\n    </div>";
var ManageComponent = (function (_super) {
    __extends(ManageComponent, _super);
    function ManageComponent(translatorService, _router, _elementRef, _modalService, _toastService) {
        var _this = _super.call(this, translatorService) || this;
        _this._router = _router;
        _this._elementRef = _elementRef;
        _this._modalService = _modalService;
        _this._toastService = _toastService;
        _this.columnDefs = [];
        _this.visibleColumns = [];
        _this.columns = [];
        _this._rowProps = [];
        _this._nodes = [];
        _this.columnOptions = {
            id: "columns",
            name: _this.translator["COLUMNS"],
            availableLabel: _this.translator["UNASSIGNED_COLUMNS"],
            assignedLabel: _this.translator["ASSIGNED_COLUMNS"],
            displayFilter: true,
            showPrimary: false,
            showOptions: true,
            items: []
        };
        _this.pkFields = [];
        _this.title = "";
        _this.showToolbar = true;
        _this.autoResizeColumns = true;
        _this.cellValueChanged = new EventEmitter();
        _this.rowSelected = new EventEmitter();
        _this.modelUpdated = new EventEmitter();
        _this.rowsLoaded = new EventEmitter();
        _this.rowDeleted = new EventEmitter();
        _this.rowValueChanged = new EventEmitter();
        return _this;
    }
    ManageComponent.prototype.ngOnInit = function () {
        this.isMobile = window.isMobile();
        this.createColumnDefs();
        var item = this.columnDefs.find(function (x) { return !!x.enableRowGroup; });
        this.initGridOptions(!!item);
        this.get();
        this._element = this._elementRef.nativeElement;
        this._element.children[0].onresize = this.onResize.bind(this);
        this.columnOptions.items = this.getItems();
    };
    ManageComponent.prototype.ngAfterViewInit = function () {
        this.addRoute = this.manageService.addRoute;
        this.gridAction = this.manageService.gridAction;
    };
    ManageComponent.prototype.getItems = function () {
        var state = this.manageService.dataColumns;
        var item = [];
        state.forEach(function (y) {
            if (y.hide === false || y.hide === undefined) {
                item.push({ name: y.headerName, value: y.field, selected: true, itemIndex: 0 });
            }
            else {
                item.push({ name: y.headerName, value: y.field, selected: false, itemIndex: 0 });
            }
        });
        item.sort(function (a, b) {
            return a.name < b.name ? -1 : 1;
        });
        return item;
    };
    ManageComponent.prototype.getRowClass = function (params) {
        this.refreshRowCount();
        return this._rowProps && this._rowProps[params.node.rowIndex] && !this._rowProps[params.node.rowIndex].valid ? "row-invalid" : "";
    };
    ManageComponent.prototype.validateRow = function (rowIndex) {
        var valid = true;
        for (var _i = 0, _a = this.manageService.dataColumns; _i < _a.length; _i++) {
            var col = _a[_i];
            var id = col.colId || col.field || "";
            if (col.required && !this.gridOptions.rowData[rowIndex][id]) {
                valid = false;
                break;
            }
        }
        if (this.RowValidatorFn && !this.RowValidatorFn(this.gridOptions.rowData[rowIndex])) {
            valid = false;
        }
        this._rowProps[rowIndex].valid = valid;
        console.log(this._rowProps);
        return valid;
    };
    ManageComponent.prototype.refreshRowCount = function () {
        var filteredrowcount = (this.gridOptions.api && this.gridOptions.api.getModel().getRowCount());
        this.totalSize = filteredrowcount;
    };
    ManageComponent.prototype.initGridOptions = function (showGrouping) {
        var _this = this;
        this.gridOptions = {
            getRowClass: this.getRowClass.bind(this),
            rowSelection: 'multiple',
            suppressCellSelection: false,
            enableColResize: true,
            enableSorting: true,
            enableFilter: true,
            enableRangeSelection: true,
            groupUseEntireRow: !showGrouping,
            showToolPanel: false,
            rowGroupPanelShow: this.isMobile || !showGrouping ? 'never' : 'always',
            autoGroupColumnDef: { cellRenderer: 'group' },
            overlayLoadingTemplate: '<i class="fa fa-spinner fa-spin fa-3x" style="color: #69be28"></i>',
            suppressContextMenu: true,
            singleClickEdit: true,
            suppressAggFuncInHeader: true,
            onFilterChanged: function () {
                _this.refreshRowCount();
            },
            headerHeight: this.isMobile ? 0 : 39,
            rowHeight: this.isMobile ? 80 : 49,
            icons: {
                filter: '<i class="is-icon is-icon-va is-filter"/>',
                sortAscending: '<i class="is-icon is-icon-va is-arrow-long-up"/>',
                sortDescending: '<i class="is-icon is-icon-va is-arrow-long-down"/>',
                groupExpanded: '<i class="is-icon is-icon-va is-caret-down"/>',
                groupContracted: '<i class="is-icon is-icon-va is-caret-right"/>',
                columnGroupOpened: '<i class="is-icon is-icon-va is-chevron-down"/>',
                columnGroupClosed: '<i class="is-icon is-icon-va is-chevron-up"/>',
                rowModelType: 'pagination'
            }
        };
        this.gridOptions.onModelUpdated = function (e) {
            _this._nodes = (_this.gridOptions.api && _this.gridOptions.api.getRenderedNodes());
            _this.modelUpdated.emit(_this._nodes);
        };
    };
    ManageComponent.prototype.get = function () {
        var _this = this;
        this.manageService.get(this.manageService.listCriteria).subscribe(function (x) {
            if (!_this.gridOptions.api) {
                return;
            }
            _this.gridOptions.rowData = x;
            _this.totalSize = x.length;
            _this.gridOptions.api.setRowData(_this.gridOptions.rowData);
            if (_this.autoResizeColumns) {
                _this.sizeToFit();
            }
            if (_this.gridOptions.rowData) {
                for (var i = 0; i < _this.gridOptions.rowData.length; i++) {
                    _this._rowProps[i] = { dirty: false, valid: true };
                }
                _this.rowsLoaded.emit(_this.gridOptions.rowData.length);
            }
        });
    };
    ManageComponent.prototype.addRows = function (numRows) {
        if (numRows === void 0) { numRows = 1; }
        var items = [];
        for (var i = 0; i < numRows; i++) {
            items.push({});
        }
        this.gridOptions.api && this.gridOptions.api.addItems(items, false);
        this.gridOptions.api && this.gridOptions.api.setFilterModel(null);
        for (var i = 0; i < numRows; i++) {
            this._rowProps.push({ dirty: false, valid: true });
            this.scrollDown();
        }
    };
    ManageComponent.prototype.scrollDown = function () {
        this.gridOptions.api && this.gridOptions.api.setInfiniteRowCount(this.gridOptions.api.paginationGetRowCount() + 1, false);
        this.gridOptions.api && this.gridOptions.api.ensureIndexVisible(this.gridOptions.api.paginationGetRowCount() - 1);
    };
    ManageComponent.prototype.showOverLay = function () {
        this.gridOptions.api && this.gridOptions.api.showLoadingOverlay();
    };
    ManageComponent.prototype.startEditingCell = function (params) {
        this.gridOptions.api && this.gridOptions.api.startEditingCell(params);
    };
    ManageComponent.prototype.setFocusedCell = function (rowIndex, colID, floating) {
        this.gridOptions.api && this.gridOptions.api.setFocusedCell(rowIndex, colID, floating);
    };
    ManageComponent.prototype.refresh = function () {
        this.get();
    };
    ManageComponent.prototype.markAsDirty = function (rowIndex) {
        if (this._rowProps.elementAt(rowIndex)) {
            this._rowProps[rowIndex].dirty = true;
        }
    };
    ManageComponent.prototype.markAsClean = function (rowIndex) {
        if (this._rowProps.elementAt(rowIndex)) {
            this._rowProps[rowIndex].dirty = false;
        }
    };
    ManageComponent.prototype.markAsValid = function (rowIndex) {
        if (this._rowProps.elementAt(rowIndex)) {
            this._rowProps[rowIndex].valid = true;
        }
    };
    ManageComponent.prototype.markAsInvalid = function (rowIndex) {
        if (this._rowProps.elementAt(rowIndex)) {
            this._rowProps[rowIndex].valid = false;
        }
    };
    ManageComponent.prototype.isValid = function (rowIndex) {
        var item = this._rowProps.elementAt(rowIndex);
        return item ? item.valid : false;
    };
    ManageComponent.prototype.isDirty = function (rowIndex) {
        var item = this._rowProps.elementAt(rowIndex);
        return item ? item.dirty : false;
    };
    ManageComponent.prototype.hasInvalidRows = function () {
        return this._rowProps.findIndex(function (x) { return !x.valid; }) != -1;
    };
    ManageComponent.prototype.getSelectedRow = function () {
        var nodes = (this.gridOptions.api && this.gridOptions.api.getSelectedNodes());
        return !Array.isEmpty(nodes) ? nodes[0] : null;
    };
    ManageComponent.prototype.createColumnDefs = function () {
        var _this = this;
        var cellRendererFn = function (params) { return null; };
        this.manageService.dataColumns.forEach(function (dataColumn) {
            var id = dataColumn.colId || dataColumn.field || "";
            var field = dataColumn.field || dataColumn.colId;
            _this.columnDefs.push({
                colId: id,
                field: field,
                sort: dataColumn.sort,
                rowGroupIndex: dataColumn.rowGroupIndex,
                pivotIndex: dataColumn.pivotIndex,
                headerName: dataColumn.headerName,
                width: dataColumn.width,
                filter: dataColumn.filter,
                editable: dataColumn.editable,
                suppressMenu: dataColumn.suppressMenu,
                suppressSorting: dataColumn.suppressSorting,
                suppressMovable: dataColumn.suppressMovable,
                suppressFilter: dataColumn.suppressFilter,
                suppressResize: dataColumn.suppressResize,
                enableRowGroup: dataColumn.enableRowGroup,
                filterParams: dataColumn.filterParams,
                cellRendererFramework: dataColumn.cellRendererFramework,
                cellStyle: dataColumn.cellStyle,
                headerClass: dataColumn.headerClass,
                cellClass: dataColumn.cellClass,
                pinned: dataColumn.pinned,
                onCellClicked: _this.isMobile ? _this.editClick.bind(_this) : dataColumn.onCellClicked,
                cellRenderer: dataColumn.cellRenderer,
                cellEditorFramework: dataColumn.cellEditorFramework,
                hide: dataColumn.hide,
                valueGetter: dataColumn.valueGetter,
                aggFunc: dataColumn.aggFunc,
                allowedAggFuncs: dataColumn.allowedAggFuncs,
                menuTabs: ['filterMenuTab']
            });
            if (!dataColumn.hide) {
                _this.visibleColumns.push(id);
            }
            _this.columns.push({ field: id, headerName: dataColumn.headerName });
        });
        this.manageService.rowActions && this.manageService.rowActions.forEach(function (managerAction) {
            _this.columnDefs.push({
                headerName: '', field: _this.manageService.id, maxWidth: _this.isMobile ? 25 : 50,
                onCellClicked: managerAction == "update" ? _this.editClick.bind(_this) : _this.deleteClick.bind(_this),
                cellClass: managerAction == "update" ? "is-icon is-icon-va is-pencil clickable" : "is-icon is-icon-va is-close clickable",
                headerClass: "ag-header-cell-action",
                cellRenderer: cellRendererFn,
                suppressMenu: true, suppressSorting: true, suppressMovable: true, suppressResize: true, enableRowGroup: false, enableValue: false, enablePivot: false,
                pinned: "right"
            });
        });
    };
    ManageComponent.prototype.editClick = function (params) {
        if (this.manageService.editRoute.indexOf("http") == 0) {
            window.location.href = String.format(this.manageService.editRoute, this.isMobile ? params.data[this.manageService.id] : params.value);
        }
        else {
            this._router.navigate([this.manageService.editRoute, this.isMobile ? params.data[this.manageService.id] : params.value]);
        }
    };
    ManageComponent.prototype.removeItem = function (params) {
        this.gridOptions.api && this.gridOptions.api.removeItems([params.node], false);
        this._rowProps.splice(params.node.rowIndex, 1);
        this.rowDeleted.emit(params.node.rowIndex);
        this.refreshRowCount();
        this.gridOptions.api && this.gridOptions.api.setFilterModel(null);
        this._toastService.success("The record has been successfully deleted.");
    };
    ManageComponent.prototype.deleteClick = function (params) {
        var _this = this;
        var args = [];
        if (this.pkFields && this.pkFields.length != 0) {
            for (var _i = 0, _a = this.pkFields; _i < _a.length; _i++) {
                var field = _a[_i];
                args.push(params.data[field]);
            }
        }
        else {
            args.push(params.value);
        }
        this._modalService.confirm(this.translator["DELETECONFIRM"]).then(function (result) {
            if (!result) {
                return;
            }
            if (args && args.length != 0) {
                (_a = _this.manageService).delete.apply(_a, args).subscribe(function (x) { _this.removeItem(params); }, function (err) {
                    if (err.header.status == 403) {
                        _this._toastService.error(_this.translator["NOTIFIERAUTHORIZATION"]);
                    }
                    if (err.header.status == 409) {
                        _this._toastService.error(_this.translator["NOTIFIERCANNOTDELETE"]);
                    }
                    if (err.header.status == -600) {
                        return _this._toastService.error(err.header.message);
                    }
                });
            }
            else {
                _this.removeItem(params);
            }
            var _a;
        });
    };
    ManageComponent.prototype.onResize = function (e) {
        var _this = this;
        setTimeout(function () {
            if (_this.autoResizeColumns) {
                _this.sizeToFit();
            }
        }, 10);
    };
    ManageComponent.prototype.sizeToFit = function () {
        var ids = [];
        this.columnDefs.forEach(function (column) {
            ids.push(column.field || "");
        });
        this.gridOptions.columnApi && this.gridOptions.columnApi.autoSizeColumns(ids);
        this.gridOptions.api && this.gridOptions.api.sizeColumnsToFit();
    };
    ManageComponent.prototype.columnsAssign = function (e) {
        var _this = this;
        if (!Array.isEmpty(e)) {
            e.forEach(function (y) {
                var state = _this.gridOptions.columnApi && _this.gridOptions.columnApi.getColumnState().find(function (x) { return x.colId === y; });
                _this.gridOptions.columnApi && _this.gridOptions.columnApi.setColumnVisible(y, state.hide);
                _this.updateColumnVisibility();
            });
            this.sizeToFit();
        }
    };
    ManageComponent.prototype.columnsUnAssign = function (e) {
        var _this = this;
        if (!Array.isEmpty(e)) {
            e.forEach(function (y) {
                var state = _this.gridOptions.columnApi && _this.gridOptions.columnApi.getColumnState().find(function (x) { return x.colId === y; });
                _this.gridOptions.columnApi && _this.gridOptions.columnApi.setColumnVisible(y, state.hide);
                _this.updateColumnVisibility();
            });
            this.sizeToFit();
        }
    };
    ManageComponent.prototype.updateColumnVisibility = function () {
        var _this = this;
        this.columns = [];
        this.visibleColumns = [];
        this.gridOptions.columnApi && this.gridOptions.columnApi.getColumnState().forEach(function (element) {
            var id = element.colId;
            if (!element.hide) {
                _this.visibleColumns.push(element.colId);
            }
            var column = _this.columnDefs.find(function (x) { return x.colId == id; });
            if (column) {
                _this.columns.push({ field: id, headerName: column.headerName });
            }
        });
    };
    ManageComponent.prototype.onColumnMoved = function (e) {
        this._isMoving = true;
        this._movedColumn = e.column;
        this.updateColumnVisibility();
        this._isMoving = false;
    };
    ManageComponent.prototype.onColumnVisible = function (e) {
        this._isMoving = false;
        this.updateColumnVisibility();
        if (this.autoResizeColumns) {
            this.sizeToFit();
        }
    };
    ManageComponent.prototype.selectRow = function (rowIndex) {
        if (this._nodes[rowIndex]) {
            this._nodes[rowIndex].setSelected(true, true);
        }
    };
    ManageComponent.prototype.onCellValueChanged = function (e) {
        this.cellValueChanged.emit(e);
    };
    ManageComponent.prototype.onRowSelected = function (e) {
        if (!e.node.isSelected() && this.isDirty(e.node.rowIndex)) {
            this.validateRow(e.node.rowIndex);
        }
        this.rowSelected.emit(e);
    };
    ManageComponent.prototype.onRowValueChanged = function (e) {
        this.rowValueChanged.emit(e);
    };
    ManageComponent.prototype.onDragStopped = function (e) {
        if (!this._movedColumn) {
            return;
        }
        var state = (this.gridOptions.columnApi && this.gridOptions.columnApi.getColumnState());
        var colID = this._movedColumn.getColId();
        var pinnedIndex = state.findIndex(function (x) { return x.pinned == "right" && x.colId != colID; });
        if (pinnedIndex == -1) {
            this.refreshRowCount();
            return;
        }
        var movedIndex = state.findIndex(function (x) { return x.colId == colID; });
        if (movedIndex >= pinnedIndex || state.find(function (x) { return x.colId == colID; }).pinned == "right") {
            this.gridOptions.columnApi && this.gridOptions.columnApi.setColumnState(this._columnState);
        }
        this._movedColumn = null;
    };
    ManageComponent.prototype.onDragStarted = function (e) {
        this._columnState = (this.gridOptions.columnApi && this.gridOptions.columnApi.getColumnState());
    };
    ManageComponent.prototype.setRowData = function (data) {
        this.gridOptions.rowData = [];
        this.gridOptions.rowData = data;
        if (this.gridOptions.api) {
            this.gridOptions.api.setRowData(data);
        }
        this.refreshRowCount();
        if (this.autoResizeColumns) {
            this.sizeToFit();
        }
    };
    Object.defineProperty(ManageComponent.prototype, "rows", {
        get: function () {
            return this.gridOptions.rowData;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(ManageComponent.prototype, "wrapperWidth", {
        get: function () {
            return "100%";
        },
        enumerable: true,
        configurable: true
    });
    ManageComponent.decorators = [
        { type: Component, args: [{
                    selector: 'is-manage',
                    template: "\n    <is-modal #columnsmodal=\"isModal\" preset=\"Close\" cancelLabel=\"Close\" size=\"small\"> \n        <is-dual [options]=\"columnOptions\" name=\"columnsActive\"  (assign)=\"columnsAssign($event)\" (unassign)=\"columnsUnAssign($event)\"\n        (assignAll)=\"columnsAssign($event)\" (unassignAll)=\"columnsUnAssign($event)\"></is-dual>                           \n    </is-modal>\n    <div *ngIf=\"showToolbar\">\n        <is-managetoolbar [id]=\"manageService.id\" [actionItems]=\"actionItems\" [title]=\"title\" [visibleColumns]=\"visibleColumns\" [columns]=\"columns\" [addRoute]=\"addRoute\" [gridAction]=\"gridAction\"></is-managetoolbar>\n    </div>" +
                        RESULTS_FOUND +
                        "<div class=\"row\">\n        <div class=\"col-12\">\n            <ag-grid-angular #agGrid style=\"height: 622px;width: 100%\" class=\"ag-iSales\" [gridOptions]=\"gridOptions\" [columnDefs]=\"columnDefs\" \n                (columnVisible)=\"onColumnVisible($event)\" (columnMoved)=\"onColumnMoved($event)\" (cellValueChanged)=\"onCellValueChanged($event)\" (rowSelected)=\"onRowSelected($event)\"\n                (rowValueChanged)=\"onRowValueChanged($event)\" (columnRowGroupChanged)=\"onColumnVisible($event)\" (dragStarted)=\"onDragStarted($event)\" (dragStopped)=\"onDragStopped($event)\">\n            </ag-grid-angular>\n        </div>\n    </div>\n\t" + RESULTS_FOUND,
                    exportAs: 'isManage'
                },] },
    ];
    ManageComponent.ctorParameters = function () { return [
        { type: TranslatorService, },
        { type: Router, },
        { type: ElementRef, },
        { type: ModalService, },
        { type: ToastService, },
    ]; };
    ManageComponent.propDecorators = {
        "columnsmodal": [{ type: ViewChild, args: ['columnsmodal',] },],
        "manageService": [{ type: Input },],
        "actionItems": [{ type: Input },],
        "pkFields": [{ type: Input },],
        "title": [{ type: Input },],
        "showToolbar": [{ type: Input },],
        "autoResizeColumns": [{ type: Input },],
        "cellValueChanged": [{ type: Output },],
        "rowSelected": [{ type: Output },],
        "modelUpdated": [{ type: Output },],
        "rowsLoaded": [{ type: Output },],
        "rowDeleted": [{ type: Output },],
        "rowValueChanged": [{ type: Output },],
        "onResize": [{ type: HostListener, args: ['window:resize', ['$event'],] },],
        "wrapperWidth": [{ type: HostBinding, args: ['style.width',] },],
    };
    return ManageComponent;
}(FrameworkComponentBase));
export { ManageComponent };
//# sourceMappingURL=manage.component.js.map