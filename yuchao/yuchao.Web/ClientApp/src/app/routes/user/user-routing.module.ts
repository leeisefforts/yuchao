import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { UserListComponent } from './user/user-list.component';
import { RecordListComponent } from './record/record-list.component';
import { RefereeComponent } from './referee/referee.component';

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
    {
        path: 'referee',
        children: [
            {
                path: '',
                component: RefereeComponent,
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
export class UserRoutingModule { }
