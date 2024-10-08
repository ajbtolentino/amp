import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthConfigModule } from './auth/auth-config.module';
import { UnauthorizedComponent } from './unauthorized/unauthorized.component';
import { HomeComponent } from './home/home.component';
import { EventsComponent } from './events/events.component';
import { InvitationsComponent } from './invitations/invitations.component';
import { ForbiddenComponent } from './forbidden/forbidden.component';
import { ProtectedComponent } from './protected/protected.component';
import { NavigationComponent } from './navigation/navigation.component';
import { provideRouter, withEnabledBlockingInitialNavigation } from '@angular/router';
import { authInterceptor, autoLoginPartialRoutesGuard, LogLevel, provideAuth } from 'angular-auth-oidc-client';
import { provideHttpClient, withInterceptors } from '@angular/common/http';


import { AvatarModule } from 'primeng/avatar';
import { AvatarGroupModule } from 'primeng/avatargroup';
import { ButtonModule } from 'primeng/button';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CalendarModule } from 'primeng/calendar';
import { ContextMenuModule } from 'primeng/contextmenu';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { DialogModule } from 'primeng/dialog';
import { DropdownModule } from 'primeng/dropdown';
import { ProgressBarModule } from 'primeng/progressbar';
import { InputTextModule } from 'primeng/inputtext';
import { InputNumberModule } from 'primeng/inputnumber';
import { MenubarModule } from 'primeng/menubar';
import { MenuModule } from 'primeng/menu';
import { MultiSelectModule } from 'primeng/multiselect';
import { RadioButtonModule } from 'primeng/radiobutton';
import { ToastModule } from 'primeng/toast';
import { TableModule } from 'primeng/table';
import { ToolbarModule } from 'primeng/toolbar';

import { MessageService, ConfirmationService } from 'primeng/api';
import { EventService } from './events/event.service';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    UnauthorizedComponent,
    HomeComponent,
    EventsComponent,
    InvitationsComponent,
    ForbiddenComponent,
    ProtectedComponent,
    NavigationComponent
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
  imports: [
    AvatarModule,
    AvatarGroupModule,
    AppRoutingModule,
    AuthConfigModule,
    ButtonModule,
    BrowserModule,
    BrowserAnimationsModule,
    BrowserModule,
    CalendarModule,
    ContextMenuModule,
    ConfirmDialogModule,
    DialogModule,
    DropdownModule,
    FormsModule,
    InputTextModule,
    InputNumberModule,
    MenubarModule,
    MenuModule,
    MultiSelectModule,
    ProgressBarModule,
    RadioButtonModule,
    TableModule,
    ToastModule,
    ToolbarModule
  ],
  providers: [provideHttpClient(withInterceptors([authInterceptor()])),
  provideAuth({
    config: {
      triggerAuthorizationResultEvent: true,
      forbiddenRoute: '/forbidden',
      unauthorizedRoute: '/unauthorized',
      logLevel: LogLevel.Debug,
      historyCleanupOff: false,
      authority: 'https://localhost:5443',
      redirectUrl: 'http://localhost:4200',
      postLogoutRedirectUri: 'http://localhost:4200',
      clientId: 'spa',
      scope: 'openid profile',
      responseType: 'code',
      silentRenew: true,
      useRefreshToken: true,
    },
  }),
  provideRouter(
    [
      { path: '', pathMatch: 'full', redirectTo: 'home' },
      { path: 'home', component: HomeComponent },
      {
        path: 'events',
        // loadChildren: () =>
        //   import('./events/events.routes').then((m) => m.routes),
        component: EventsComponent,
        canActivate: [autoLoginPartialRoutesGuard],
      },
      { path: 'invitations', component: InvitationsComponent },
      {
        path: 'protected',
        component: ProtectedComponent,
        canActivate: [autoLoginPartialRoutesGuard],
      },
      {
        path: 'forbidden',
        component: ForbiddenComponent,
        canActivate: [autoLoginPartialRoutesGuard],
      },
      { path: 'unauthorized', component: UnauthorizedComponent },
    ],
    withEnabledBlockingInitialNavigation()
  ),
    EventService,
    MessageService,
    ConfirmationService,],
  bootstrap: [AppComponent]
})
export class AppModule { }
