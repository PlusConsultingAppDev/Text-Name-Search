export interface ColData {
    colId?: string;
    field?: string;
    headerName?: string;
    width?: number;
    cellStyle?: {} | ((params: any) => {});
    cellRendererFramework?: any;
    cellEditorFramework?: any;
    cellRenderer?: any;
    maxWidth?: number;
    filter?: any;
    filterParams?: any;
    valueGetter?: any;
    aggFunc?: string;
    allowedAggFuncs?: any;
    cellClass?: string | string[] | ((cellClassParams: any) => string | string[]);
    headerClass?: string | string[] | ((params: any) => string | string[]);
    onCellClicked?: Function;
    pinned?: boolean | string;
    editable?: boolean;
    suppressMenu?: boolean;
    suppressSorting?: boolean;
    suppressMovable?: boolean;
    suppressResize?: boolean;
    suppressFilter?: boolean;
    enableRowGroup?: boolean;
    enableValue?: boolean;
    enablePivot?: boolean;
    required?: boolean;
    validatorFn?: (e: any) => boolean;
    hide?: boolean;
    sort?: string;
    rowGroupIndex?: number;
    pivotIndex?: number;
}
export interface IManageService {
    id: string;
    dataColumns: ColData[];
    mainActions: string[];
    addRoute: string;
    gridAction: boolean;
    editRoute: string;
    listCriteria?: any;
    rowActions?: string[];
    get(...args: any[]): any;
    getById(...args: any[]): any;
    add(...args: any[]): any;
    delete(...args: any[]): any;
    update(...args: any[]): any;
}
export interface ActionItem {
    label?: string;
    click?: (value?: any) => void;
}
export interface ActionItems {
    actions?: ActionItem[];
}
