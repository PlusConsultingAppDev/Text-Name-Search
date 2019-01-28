import { IManageService, ColData } from './models';
export declare abstract class ManageService implements IManageService {
    private _idNumeric;
    protected endPoint: string;
    constructor(_idNumeric?: boolean | undefined);
    id: string;
    dataColumns: ColData[];
    rowActions: string[];
    addRoute: string;
    editRoute: string;
    gridAction: boolean;
    mainActions: string[];
    listCriteria: any;
    abstract get(...args: any[]): any;
    abstract getById(...args: any[]): any;
    abstract add(...args: any[]): any;
    abstract delete(...args: any[]): any;
    abstract update(...args: any[]): any;
    protected getEndPoint(path: string, id: any, ignoreEmpty?: boolean): string;
}
