import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientInMemoryWebApiModule } from 'angular-in-memory-web-api';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { MatListModule, MatButtonModule, MatFormFieldModule,
   MatDialogModule, MatInputModule, MatToolbarModule, MatDividerModule, MatIconModule } from '@angular/material';

import { AppComponent } from './app.component';
import { SearchItemsListComponent } from './search-items-list/search-items-list.component';
import { SearchComponent } from './search/search.component';

import { DataAPIService } from './services/data-api.service';
import { SearchItemFormComponent } from './search-item-form/search-item-form.component';


@NgModule({
  declarations: [
    AppComponent,
    SearchItemsListComponent,
    SearchComponent,
    SearchItemFormComponent
  ],
  imports: [
    BrowserModule, HttpClientModule, ReactiveFormsModule, FormsModule,
    BrowserAnimationsModule,
    MatListModule, MatButtonModule, MatFormFieldModule,
     MatDialogModule, MatInputModule, MatToolbarModule, MatDividerModule, MatIconModule,
    HttpClientInMemoryWebApiModule.forRoot(DataAPIService, {dataEncapsulation: false})
  ],
  entryComponents: [
    SearchItemFormComponent
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
