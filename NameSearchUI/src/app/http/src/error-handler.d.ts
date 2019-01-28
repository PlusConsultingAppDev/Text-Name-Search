import { ResponseItem } from './models';
export declare class ErrorHandler {
    static handleError: (res: ResponseItem, error?: (error?: any) => void) => void;
}
