import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { UserListComponent } from './user/user-list.component';
import { RecordListComponent } from './record/record-list.component';

const routes: Routes = [
  {
    path: 'user',
    children: [
      {
        path: '',
        component: UserListComponent,
        children: [
        ],
      },
    ],
  },
  {
    path: 'record',
    children: [
      {
        path: '',
        component: RecordListComponent,
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
export class UserRoutingModule {}
