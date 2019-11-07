import { NgModule } from '@angular/core';

import { SharedModule } from '@shared';
import { GameRoutingModule } from './game-routing.module';

import { GameListComponent } from './list/game-list.component';
import { listEditComponent } from './list/edit/edit.component';
const COMPONENTS = [GameListComponent];

const COMPONENTS_NOROUNT = [listEditComponent];

@NgModule({
  imports: [SharedModule, GameRoutingModule],
  declarations: [...COMPONENTS, ...COMPONENTS_NOROUNT],
  entryComponents: COMPONENTS_NOROUNT,
})
export class GameModule {}
