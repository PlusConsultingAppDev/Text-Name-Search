import { Router } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import { PartialObserver } from 'rxjs/Observer';
import { Subscription } from 'rxjs/Subscription';
import { ResponseItem } from './models';
export declare class ObservableHttp extends Observable<any> {
    private observable;
    private router;
    constructor(observable: Observable<ResponseItem>, router: Router);
    subscribe(observerOrNext?: PartialObserver<any> | ((value: any) => void), error?: (error: any) => void, complete?: () => void): Subscription;
}
