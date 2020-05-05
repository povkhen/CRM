import { BrowserModule, HammerGestureConfig, HAMMER_GESTURE_CONFIG } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import {HttpClientModule} from '@angular/common/http';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { BsDropdownModule, TabsModule, BsDatepickerModule } from 'ngx-bootstrap';
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
import { AdminComponent } from './admin/admin.component';
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
      AppComponent,
      NavComponent,
      RegisterComponent,
      LoginComponent,
      HomeComponent,
      CoworkersComponent,
      CoworkerCardComponent,
      CoworkerDetailedComponent,
      CoworkerEditComponent,
      AdminComponent,
      DashboardComponent,
      MessagesComponent,
      ClientsComponent,
      PhotoEditorComponent,
      TimeAgoPipe
   ],
   imports: [
      BrowserModule,
      BrowserAnimationsModule,
      HttpClientModule,
      FormsModule,
      BsDatepickerModule.forRoot(),
      ReactiveFormsModule,
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
      AuthGuard,
      PreventUnsavedChanges,
      UserService,
      CoworkerDetailResolver,
      CoworkersResolver,
      CoworkerEditResolver,
      ErrorInterceptorProvider,
      { provide: HAMMER_GESTURE_CONFIG, useClass: CustomHammerConfig }
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
