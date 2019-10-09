import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { VenueListComponent } from './flist/venue-flist.component';

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
        component: VenueListComponent,
        // children: [
        //   { path: 'articles', component: ProListArticlesComponent },
        //   { path: 'projects', component: ProListProjectsComponent },
        //   { path: 'applications', component: ProListApplicationsComponent },
        // ],
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class VenueRoutingModule {}
