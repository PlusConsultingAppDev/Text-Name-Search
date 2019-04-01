import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { TranslateModule } from '@ngx-translate/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { LoginRoutingModule } from './login-routing.module';
import { LoginComponent } from './login.component';
import { UserService } from '../../services/user.service';

@NgModule({
  imports: [CommonModule, ReactiveFormsModule, TranslateModule, NgbModule, LoginRoutingModule],
  declarations: [LoginComponent],
  providers: [UserService]
})
export class LoginModule {}
