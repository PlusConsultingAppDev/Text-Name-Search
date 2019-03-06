import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material';
import { SearchService } from '../services/search.service';

@Component({
  selector: 'app-search-item-form',
  templateUrl: './search-item-form.component.html',
  styleUrls: ['./search-item-form.component.scss']
})
export class SearchItemFormComponent implements OnInit {
  // This component would be changed to accommodate for multiple types of forms
  // When the name type is selected the below group would be used

  searchItemForm: FormGroup;

  constructor(public dialogRef: MatDialogRef<SearchItemFormComponent>, private searchService: SearchService) { }

  ngOnInit() {
    this.searchItemForm = new FormGroup({
      'firstName': new FormControl('', Validators.required),
      'middleName': new FormControl('', Validators.required),
      'lastName': new FormControl('', Validators.required),
    });
  }

  onSubmit() {
    this.searchService.addSearchItem(this.searchItemForm.value).subscribe(() => this.dialogRef.close());
  }

}
