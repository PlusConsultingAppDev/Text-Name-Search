import { Component, OnInit } from '@angular/core';
import { SearchService } from '../services/search.service';
import { ISearchResult } from '../models/isearch-result';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss']
})
export class SearchComponent implements OnInit {

  newsArticle: string;
  results: ISearchResult[];

  constructor(private searchService: SearchService) { }

  ngOnInit() {
  }

  onSubmit() {
    this.searchService.search(this.newsArticle).subscribe(
      (results) => this.results = results
    );

  }
}
