import { Component, OnInit } from '@angular/core';
import { SearchService } from '../services/search.service';
import { MatDialogRef, MatDialog } from '@angular/material';
import { SearchItemFormComponent } from '../search-item-form/search-item-form.component';
import { IName } from '../models/iname';

@Component({
  selector: 'app-search-items-list',
  templateUrl: './search-items-list.component.html',
  styleUrls: ['./search-items-list.component.scss']
})
export class SearchItemsListComponent implements OnInit {

 // searchItems: IName[] = [];
  constructor(private searchService: SearchService, public dialog: MatDialog) { }


  get searchItems(): IName[] {
    return this.searchService.searchItems;
  }

  ngOnInit() {
    this.getSearchItems();
  }

  createSearchItem() {
    const dialogRef = this.dialog.open(SearchItemFormComponent);

    dialogRef.afterClosed().subscribe(() => this.getSearchItems());

  }

  getSearchItems() {
    this.searchService.getSearchItems().subscribe((items: any[]) => {
      this.searchService.searchItems = items;
    });
  }

  deleteSearchItem(item: IName) {
    this.searchService.deleteSearchItem(item.id).subscribe((items: IName) => {
      this.getSearchItems();
    });
  }

}
