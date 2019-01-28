import { ComponentFactoryResolver, ViewContainerRef, OnDestroy } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
export declare abstract class AppComponentBase implements OnDestroy {
    constructor(route: ActivatedRoute,  componentFactoryResolver: ComponentFactoryResolver, viewContainerRef: ViewContainerRef);
    ngOnDestroy(): void;
}
