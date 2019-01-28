import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { SearchComponent } from 'search.component';
import { SearchService } from 'search.service';

@NgModule({
	imports: [CommonModule, FormsModule],
	declarations: [
		SearchComponent
	],
	providers: [SearchService]
})
export class SearchModule { }