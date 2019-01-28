import { NgModule, APP_INITIALIZER } from '@angular/core';
import { APP_BASE_HREF } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SearchModule } from './search/search-routing.module';
import { AppComponent } from './app.component';

@NgModule({
    imports: [ SearchModule ],
    declarations: [ AppComponent ],
    bootstrap: [ AppComponent ]
})
export class AppModule { }