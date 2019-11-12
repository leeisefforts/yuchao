import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ConsumeListComponent } from './consume/consume.component';
import { IncrementListComponent } from './increment/increment.component';

const routes: Routes = [
  {
    path: 'consume',
    children: [
      {
        path: '',
        component: ConsumeListComponent,
        children: [
        ],
      },
    ],
  },
  {
    path: 'increment',
    children: [
      {
        path: '',
        component: IncrementListComponent,
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
export class DashboarRoutingModule {}
