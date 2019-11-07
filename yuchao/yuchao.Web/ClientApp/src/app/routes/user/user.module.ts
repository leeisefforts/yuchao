import { NgModule } from '@angular/core';

import { SharedModule } from '@shared';
import { UserRoutingModule } from './user-routing.module';

import { UserListComponent } from './user/user-list.component';
import { RecordListComponent } from './record/record-list.component';
import { recordEditComponent } from './record/edit/edit.component';
const COMPONENTS = [UserListComponent,RecordListComponent];

const COMPONENTS_NOROUNT = [recordEditComponent];

@NgModule({
  imports: [SharedModule, UserRoutingModule],
  declarations: [...COMPONENTS, ...COMPONENTS_NOROUNT],
  entryComponents: COMPONENTS_NOROUNT,
})
export class UserModule {}
