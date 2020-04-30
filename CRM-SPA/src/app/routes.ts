import {Routes} from '@angular/router';
import { HomeComponent } from './home/home.component';
import { CoworkersComponent } from './coworkers_folder/coworkers/coworkers.component';
import { MessagesComponent } from './messages/messages.component';
import { AdminComponent } from './admin/admin.component';
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

export const appRoutes: Routes = [
    { path: '', component: HomeComponent},
    { path: 'login', component: LoginComponent},
    {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
            { path: 'admin', component: AdminComponent},
            { path: 'dashboard', component: DashboardComponent},
            { path: 'dashboard/coworkers', component: CoworkersComponent,
                resolve: {users: CoworkersResolver}},
            { path: 'dashboard/coworkers/:id', component: CoworkerDetailedComponent,
                resolve: {user: CoworkerDetailResolver}},
            { path: 'coworker/edit', component: CoworkerEditComponent,
                resolve: {user: CoworkerEditResolver}, canDeactivate: [PreventUnsavedChanges]},
            { path: 'dashboard/clients', component: ClientsComponent},
            { path: 'messages', component: MessagesComponent},
        ]
    },
    { path: '**', redirectTo: '', pathMatch: 'full'}
];
