import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { VenueFlistComponent } from './flist/venue-flist.component';
import { VenueListComponent } from './list/venue-list.component';

const routes: Routes = [
  //   {
  //     path: 'form',
  //     children: [
  //       { path: 'basic-form', component: BasicFormComponent },
  //       { path: 'step-form', component: StepFormComponent },
  //       { path: 'advanced-form', component: AdvancedFormComponent },
  //     ],
  //   },
  {
    path: 'flist',
    children: [
      {
        path: '',
        component: VenueFlistComponent,
        children: [
          // { path: 'basic-list', component: ProBasicListComponent },
          // { path: 'articles', component: ProListArticlesComponent },
          // { path: 'projects', component: ProListProjectsComponent },
          // { path: 'applications', component: ProListApplicationsComponent },
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
          // { path: 'basic-list', component: ProBasicListComponent },
          // { path: 'articles', component: ProListArticlesComponent },
          // { path: 'projects', component: ProListProjectsComponent },
          // { path: 'applications', component: ProListApplicationsComponent },
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
