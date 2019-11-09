import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { GameListComponent } from './list/game-list.component';

const routes: Routes = [
  {
    path: 'list',
    children: [
      {
        path: '',
        component: GameListComponent,
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
export class GameRoutingModule {}
