import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { VenueFlistComponent } from './flist/venue-flist.component';
import { VenueListComponent } from './list/venue-list.component';

const routes: Routes = [
  {
    path: 'flist',
    children: [
      {
        path: '',
        component: VenueFlistComponent,
        children: [
        ],
      },
    ],
  },
  {
    path: 'list',
    children: [
      {
        path: '',
        component: VenueListComponent,
        children: [
        ],
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class VenueRoutingModule {}
