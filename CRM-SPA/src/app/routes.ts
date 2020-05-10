import {Routes} from '@angular/router';
import { HomeComponent } from './home/home.component';
import { CoworkersComponent } from './coworkers_folder/coworkers/coworkers.component';
import { MessagesComponent } from './messages/messages.component';
import { LoginComponent } from './login/login.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { AuthGuard } from './_guards/auth.guard';
import { ClientsComponent } from './clients/clients.component';
import { CoworkerDetailedComponent } from './coworkers_folder/coworker-detailed/coworker-detailed.component';
import { CoworkerDetailResolver } from './_resolvers/coworker-detailed.resolver';
import { CoworkersResolver } from './_resolvers/coworkers.resolver';
import { CoworkerEditComponent } from './coworkers_folder/coworker-edit/coworker-edit.component';
import { CoworkerEditResolver } from './_resolvers/coworker-edit.resolver';
import { PreventUnsavedChanges } from './_guards/prevent-unsaved-changes.guard';
import { ClientsResolver } from './_resolvers/clients.resolver';
import { MessagesResolver } from './_resolvers/messages.resolver';
import { AdminPanelComponent } from './admin-folder/admin-panel/admin-panel.component';

export const appRoutes: Routes = [
    { path: '', component: HomeComponent},
    { path: 'login', component: LoginComponent},
    {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
            { path: 'dashboard', component: DashboardComponent},
            { path: 'dashboard/coworkers', component: CoworkersComponent,
                resolve: {users: CoworkersResolver}},
            { path: 'dashboard/clients', component: ClientsComponent,
                resolve: {clients: ClientsResolver}},
            { path: 'dashboard/coworkers/:id', component: CoworkerDetailedComponent,
                resolve: {user: CoworkerDetailResolver}},
            { path: 'coworker/edit', component: CoworkerEditComponent,
                resolve: {user: CoworkerEditResolver}, canDeactivate: [PreventUnsavedChanges]},
            { path: 'messages', component: MessagesComponent,
                resolve: {messages: MessagesResolver}},
            { path: 'admin', component: AdminPanelComponent, data: {roles: ['Admin', 'Moderator', 'HR']}}
        ]
    },
    { path: '**', redirectTo: '', pathMatch: 'full'}
];
