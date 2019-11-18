import { NgModule } from '@angular/core';

import { SharedModule } from '@shared';
import { DashboarRoutingModule } from './dashboar-routing.module';

import { ConsumeListComponent } from './consume/consume.component';
import { IncrementListComponent } from './increment/increment.component';
import { listEditComponent } from './increment/edit/edit.component';
const COMPONENTS = [ConsumeListComponent,IncrementListComponent];

const COMPONENTS_NOROUNT = [listEditComponent];

@NgModule({
  imports: [SharedModule, DashboarRoutingModule],
  declarations: [...COMPONENTS, ...COMPONENTS_NOROUNT],
  entryComponents: COMPONENTS_NOROUNT,
})
export class DashboarModule {}
