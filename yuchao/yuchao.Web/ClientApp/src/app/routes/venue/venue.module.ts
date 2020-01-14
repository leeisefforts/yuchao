import { NgModule } from '@angular/core';

import { SharedModule } from '@shared';
import { VenueRoutingModule } from './venue-routing.module';

import { VenueFlistComponent } from './flist/venue-flist.component';
import { flistEditComponent } from './flist/edit/edit.component';
import { priceEditComponent } from './flist/edit/price.component';
import { flistAccountComponent } from './flist/account/account.component';
import { VenueListComponent } from './list/venue-list.component';
import { listEditComponent } from './list/edit/edit.component';
const COMPONENTS = [VenueFlistComponent,VenueListComponent];

const COMPONENTS_NOROUNT = [flistEditComponent, priceEditComponent, listEditComponent, flistAccountComponent];

@NgModule({
  imports: [SharedModule, VenueRoutingModule],
  declarations: [...COMPONENTS, ...COMPONENTS_NOROUNT],
  entryComponents: COMPONENTS_NOROUNT,
})
export class VenueModule {}
