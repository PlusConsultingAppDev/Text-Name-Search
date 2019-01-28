import { Component, AfterViewInit, OnDestroy, ComponentFactoryResolver, ViewContainerRef, ViewChild } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs/Subscription';
import { AppComponentBase } from './app-base.component';

@Component({
	selector: 'is-app',
	templateUrl: './app.component.html',
	exportAs: 'isApp'
})

export class AppComponent extends AppComponentBase implements OnDestroy {

	public navBarTheme: string;
	public logo: string;
	public headerTheme: string;
	public headerDisplay: string | null;

	private transSubs: Subscription;


	constructor(route: ActivatedRoute, private router: Router,
		componentFactoryResolver: ComponentFactoryResolver, viewContainerRef: ViewContainerRef) {

		super(route, componentFactoryResolver, viewContainerRef);
		this.headerTheme = "theme-pinched";
	}

	ngOnDestroy() {
		super.ngOnDestroy();
		this.transSubs && this.transSubs.unsubscribe();
	}

	public hasToken() {
		let url = this.router.url;
		return url != "/" && url.indexOf("/login") == -1;
	}
}