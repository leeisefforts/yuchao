import { NgModule } from '@angular/core';

import { SharedModule } from '@shared';
import { VenueRoutingModule } from './venue-routing.module';

import { VenueListComponent } from './flist/venue-flist.component';
const COMPONENTS = [VenueListComponent];

const COMPONENTS_NOROUNT = [];

@NgModule({
  imports: [SharedModule, VenueRoutingModule],
  declarations: [...COMPONENTS, ...COMPONENTS_NOROUNT],
  entryComponents: COMPONENTS_NOROUNT,
})
export class VenueModule {}
