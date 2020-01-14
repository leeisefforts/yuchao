import { NgModule } from '@angular/core';

import { SharedModule } from '@shared';
import { UserRoutingModule } from './user-routing.module';

import { UserListComponent } from './user/user-list.component';
import { RecordListComponent } from './record/record-list.component';
import { recordEditComponent } from './record/edit/edit.component';
import { refereeEditComponent } from './referee/edit/edit.component';
import { RefereeComponent } from './referee/referee.component';
const COMPONENTS = [UserListComponent, RecordListComponent,RefereeComponent];

const COMPONENTS_NOROUNT = [recordEditComponent, refereeEditComponent];

@NgModule({
  imports: [SharedModule, UserRoutingModule],
  declarations: [...COMPONENTS, ...COMPONENTS_NOROUNT],
  entryComponents: COMPONENTS_NOROUNT,
})
export class UserModule {}
