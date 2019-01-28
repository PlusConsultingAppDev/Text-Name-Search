import { Component, OnInit, ViewChild, ViewChildren, QueryList } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ManageComponent } from '../manage';
import { SearchService } from './search.service';

@Component({
	selector: 'is-search',
	templateUrl: './search.html',
	providers: [SearchService],
})
export class SearchComponent {

    @ViewChild('manage') manage: ManageComponent;

    public firstName: string;
    public middleInitial: string;
    public lastName: string;

    constructor(route: ActivatedRoute, public service: SearchService) {
	}

    public searchNames() {
		this.service.searchNames(this.firstName, this.middleInitial, this.lastName).subscribe((response: any) => {
			setTimeout(() => {
				if (this.manage) {
					this.manage.setRowData(response);
				}
			}, 0);
		});
	}
}
