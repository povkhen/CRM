import { BrowserModule, HammerGestureConfig, HAMMER_GESTURE_CONFIG } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import {HttpClientModule} from '@angular/common/http';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { BsDropdownModule, TabsModule, BsDatepickerModule, PaginationModule, ButtonsModule, ModalModule } from 'ngx-bootstrap';
import { RouterModule } from '@angular/router';
import { JwtModule } from '@auth0/angular-jwt';
import { NgxGalleryModule } from 'ngx-gallery';
import { FileUploadModule } from 'ng2-file-upload';
import {TimeAgoPipe} from 'time-ago-pipe';

import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { AuthService } from './_services/auth.service';
import { UserService } from './_services/user.service';
import { ErrorInterceptorProvider } from './_services/error.interceptor';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';
import { CoworkersComponent } from './coworkers_folder/coworkers/coworkers.component';
import { CoworkerCardComponent } from './coworkers_folder/coworker-card/coworker-card.component';
import { MessagesComponent } from './messages/messages.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { ClientsComponent } from './clients/clients.component';
import { AuthGuard } from './_guards/auth.guard';
import { appRoutes } from './routes';
import { CoworkerDetailedComponent } from './coworkers_folder/coworker-detailed/coworker-detailed.component';
import { CoworkerDetailResolver } from './_resolvers/coworker-detailed.resolver';
import { CoworkersResolver } from './_resolvers/coworkers.resolver';
import { CoworkerEditComponent } from './coworkers_folder/coworker-edit/coworker-edit.component';
import { CoworkerEditResolver } from './_resolvers/coworker-edit.resolver';
import { PreventUnsavedChanges } from './_guards/prevent-unsaved-changes.guard';
import { PhotoEditorComponent } from './coworkers_folder/photo-editor/photo-editor.component';
import { ClientsResolver } from './_resolvers/clients.resolver';
import { MessagesResolver } from './_resolvers/messages.resolver';
import { CoworkersMessagesComponent } from './coworkers_folder/coworkers-messages/coworkers-messages.component';
import { AdminPanelComponent } from './admin-folder/admin-panel/admin-panel.component';
import { HasRoleDirective } from './_directives/hasRole.directive';
import { UserManagementComponent } from './admin-folder/admin-panel/user-management/user-management.component';
import { PhotoManagementComponent } from './admin-folder/admin-panel/photo-management/photo-management.component';
import { AdminService } from './_services/admin.service';
import { RolesModalComponent } from './admin-folder/admin-panel/roles-modal/roles-modal.component';

export function tokenGetter() {
   return localStorage.getItem('token');
}

export class CustomHammerConfig extends HammerGestureConfig  {
   overrides = {
       pinch: { enable: false },
       rotate: { enable: false }
   };
}

@NgModule({
   declarations: [
      AdminPanelComponent,
      AppComponent,
      NavComponent,
      RegisterComponent,
      LoginComponent,
      HomeComponent,
      CoworkersComponent,
      CoworkerCardComponent,
      CoworkerDetailedComponent,
      CoworkerEditComponent,
      CoworkersMessagesComponent,
      DashboardComponent,
      MessagesComponent,
      ClientsComponent,
      PhotoEditorComponent,
      TimeAgoPipe,
      HasRoleDirective,
      UserManagementComponent,
      PhotoManagementComponent,
      RolesModalComponent
   ],
   imports: [
      BrowserModule,
      PaginationModule.forRoot(),
      ButtonsModule.forRoot(),
      BrowserAnimationsModule,
      HttpClientModule,
      FormsModule,
      BsDatepickerModule.forRoot(),
      ReactiveFormsModule,
      ModalModule.forRoot(),
      BsDropdownModule.forRoot(),
      TabsModule.forRoot(),
      RouterModule.forRoot(appRoutes),
      NgxGalleryModule,
      FileUploadModule,
      JwtModule.forRoot({
         config: {
            // tslint:disable-next-line: object-literal-shorthand
            tokenGetter: tokenGetter,
            whitelistedDomains: ['localhost:5000'],
            blacklistedRoutes: ['localhost:5000/api/auth']
         }
      })
   ],
   providers: [
      AuthService,
      AdminService,
      AuthGuard,
      PreventUnsavedChanges,
      UserService,
      CoworkerDetailResolver,
      MessagesResolver,
      ClientsResolver,
      CoworkersResolver,
      CoworkerEditResolver,
      ErrorInterceptorProvider,
      { provide: HAMMER_GESTURE_CONFIG, useClass: CustomHammerConfig }
   ],
   entryComponents: [
      RolesModalComponent
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
