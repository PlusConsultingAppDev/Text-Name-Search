import { Component, OnInit, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { finalize } from 'rxjs/operators';

import { NameService } from '../../services/name.service';
import { NameModel } from '../../models/NameModel';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  names: NameModel[];
  isLoading: boolean;
  myForm: FormGroup;

  constructor(private nameService: NameService, private router: Router, private fb: FormBuilder) {}

  ngOnInit() {
    this.selectItem(null, null);
    this.isLoading = true;
    this.loadGrid();
  }

  loadGrid() {
    this.nameService
      .getNameAll()
      .pipe(
        finalize(() => {
          this.isLoading = false;
        })
      )
      .subscribe((names: NameModel[]) => {
        this.search(names);

        this.names = names;
      });
  }
  selectItem(event: any, name: NameModel) {
    if (!name) {
      name = new NameModel('00000000-0000-0000-0000-000000000000', '', '', '');
    }

    this.myForm = new FormGroup({
      id: new FormControl(name.id),
      firstName: new FormControl(name.firstName, Validators.required),
      middleName: new FormControl(name.middleName, Validators.required),
      lastName: new FormControl(name.lastName, Validators.required)
    });
  }
  deleteItem(event: any, name: NameModel) {
    this.nameService
      .deleteNameById(name.id)
      .pipe()
      .subscribe(() => {
        this.loadGrid();
      });
  }
  submitItem() {
    var name = new NameModel(
      this.myForm.get('id').value,
      this.myForm.get('firstName').value.trim(),
      this.myForm.get('middleName').value.trim(),
      this.myForm.get('lastName').value.trim()
    );

    this.nameService
      .saveName(name)
      .pipe()
      .subscribe(() => {
        this.loadGrid();
        this.selectItem(null, null);
      });
  }
  search(names: NameModel[]) {
    var textToSearch =
      'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas Connor Smith dignissim erat consequat, placerat erat in, lobortis nulla. Vestibulum scelerisque magna ut urna hendrerit, finibus rutrum dolor faucibus. Seth David Greenly Aliquam feugiat urna vel tellus congue, non dictum orci varius. Vivamus tristique, lorem ut hendrerit aliquet, nulla nisl eleifend quam, sed laoreet erat lorem non diam. Nulla facilisi. Etiam bibendum Seth D. Greenly nec diam sed vestibulum. Nunc ipsum enim, imperdiet eu feugiat vel, vestibulum a justo. Donec efficitur velit porta odio consequat viverra. Quisque in tristique enim, sed euismod purus. Nullam eu leo pellentesque, porta leo in, Sarah Greenly maximus risus. Morbi in risus id risus feugiat egestas. David black Nunc egestas, metus at volutpat tempus, massa justo venenatis arcu, a ornare mauris arcu at justo. Sed accumsan, David W. black erat vitae euismod facilisis, risus odio bibendum neque, sit amet tincidunt diam ante et dolor. Morbi leo felis, posuere id ex ut, varius ornare libero.  '.toLowerCase() +
      'Suspendisse lacus ipsum, molestie vel nulla id, commodo hendrerit est.Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas.Maecenas finibus magna libero, vehicula David Black luctus lorem varius non.Integer ut tempor massa, eget sollicitudin purus.Mauris efficitur in ipsum eu consectetur.Aliquam vitae nulla vitae sapien laoreet vehicula et et ex.Donec molestie auctor lorem eget Seth rhoncus.Donec ornare sapien in turpis auctor, ut commodo David Warren Black augue cursus.Pellentesque fermentum nunc turpis, eu vulputate Connor Smith leo aliquet eu.Nam quis pretium felis.Sed id turpis sed lacus malesuada pulvinar et eget leo.Vestibulum eget dapibus mi.Duis tempor nec tellus vitae aliquet.Nam sapien massa, ornare non posuere sit amet, cursus a velit.Curabitur nec consectetur metus.Donec porttitor at libero a blandit.  '.toLowerCase() +
      'Proin luctus augue sit amet sem varius ultricies.Vestibulum nibh ligula, sollicitudin ac lectus eu, congue imperdiet quam.Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas.Nulla ac nisl sed risus tincidunt finibus.Curabitur viverra eget justo non dignissim.Seth D Greenly Proin varius malesuada enim non vulputate.Integer fermentum interdum felis, luctus commodo nisi pulvinar quis.  '.toLowerCase() +
      'Donec pharetra faucibus urna a semper.Morbi tempor maximus Connor G Smith lectus sit amet interdum.Integer pretium ut est non vulputate.Aliquam pulvinar turpis laoreet dictum ultrices.Aenean diam metus, David semper at quam et, iaculis viverra ante.Sed efficitur lorem quis consectetur mollis.Vivamus ut purus mauris.Quisque at gravida dolor.Fusce congue magna enim, ut placerat est porttitor a.Phasellus rutrum, neque lacinia Gary Grossman cursus mattis, est lacus placerat nunc, a ornare enim nunc at justo.Sed urna leo, tincidunt elementum consequat vel, condimentum sed lacus.  '.toLowerCase();

    for (var i = 0; i < names.length; i++) {
      names[i].count =
        this.occurrences(textToSearch, names[i].firstName.toLowerCase() + ' ' + names[i].lastName.toLowerCase()) +
        this.occurrences(
          textToSearch,
          names[i].firstName.toLowerCase() +
            ' ' +
            names[i].middleName.toLowerCase() +
            ' ' +
            names[i].lastName.toLowerCase()
        ) +
        this.occurrences(
          textToSearch,
          names[i].firstName.toLowerCase() +
            ' ' +
            names[i].middleName.substr(0, 1).toLowerCase() +
            '. ' +
            names[i].lastName.toLowerCase()
        ) +
        this.occurrences(
          textToSearch,
          names[i].firstName.toLowerCase() +
            ' ' +
            names[i].middleName.substr(0, 1).toLowerCase() +
            ' ' +
            names[i].lastName.toLowerCase()
        );
    }
  }
  occurrences(full: string, subString: string) {
    if (subString.length <= 0) return full.length + 1;
    var n = 0,
      pos = 0,
      step = subString.length;

    while (true) {
      pos = full.indexOf(subString, pos);
      if (pos >= 0) {
        ++n;
        pos += step;
      } else break;
    }

    return n;
  }
}
