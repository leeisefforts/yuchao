import { NgModule } from '@angular/core';

import { SharedModule } from '@shared';
import { VenueRoutingModule } from './venue-routing.module';

import { VenueFlistComponent } from './flist/venue-flist.component';
import { flistEditComponent } from './flist/edit/edit.component';
import { VenueListComponent } from './list/venue-list.component';
import { listEditComponent } from './list/edit/edit.component';
const COMPONENTS = [VenueFlistComponent,VenueListComponent];

const COMPONENTS_NOROUNT = [flistEditComponent,listEditComponent];

@NgModule({
  imports: [SharedModule, VenueRoutingModule],
  declarations: [...COMPONENTS, ...COMPONENTS_NOROUNT],
  entryComponents: COMPONENTS_NOROUNT,
})
export class VenueModule {}
