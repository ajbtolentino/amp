import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthConfigModule } from './core/auth-config.module';
import { UnauthorizedComponent } from './shared/unauthorized/unauthorized.component';
import { HomeComponent } from './features/home/home.component';
import { ForbiddenComponent } from './shared/forbidden/forbidden.component';
import { NavigationComponent } from './shared/navigation/navigation.component';
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
import { EventService } from './core/event.service';
import { FormsModule } from '@angular/forms';
import { EventDetailsComponent } from './features/event-details/event-details.component';
import { EventListComponent } from './features/event-list/event-list.component';
import { InvitationDetailsComponent } from './features/invitation-details/invitation-details.component';
import { InvitationService } from './core/invitation.service';
import { GuestListComponent } from './features/guest-list/guest-list.component';
import { GuestService } from './core/guest.service';

import { environment } from './../environments/environment';

@NgModule({
  declarations: [
    AppComponent,
    UnauthorizedComponent,
    HomeComponent,
    ForbiddenComponent,
    NavigationComponent,
    EventDetailsComponent,
    EventListComponent,
    InvitationDetailsComponent,
    GuestListComponent,
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
      authority: environment.authUrl,
      redirectUrl: window.location.origin,
      postLogoutRedirectUri: window.location.origin,
      clientId: 'spa',
      scope: 'openid profile',
      responseType: 'code',
      silentRenew: true,
      useRefreshToken: true,
    },
  }),
  provideRouter(
    [
      {
        path: '',
        pathMatch: 'full',
        redirectTo: 'home'
      },
      {
        path: 'home',
        component: HomeComponent
      },
      {
        path: 'events',
        component: EventListComponent,
        canActivate: [autoLoginPartialRoutesGuard],
      },
      {
        path: 'events/:id',
        component: EventDetailsComponent,
        canActivate: [autoLoginPartialRoutesGuard],
      },
      {
        path: 'guests',
        component: GuestListComponent,
        canActivate: [autoLoginPartialRoutesGuard],
      },
      {
        path: 'invitations/:id',
        component: InvitationDetailsComponent,
        canActivate: [autoLoginPartialRoutesGuard],
      },
      {
        path: 'forbidden',
        component: ForbiddenComponent,
        canActivate: [autoLoginPartialRoutesGuard],
      },
      {
        path: 'unauthorized',
        component: UnauthorizedComponent
      },
    ],
    withEnabledBlockingInitialNavigation()
  ),
    EventService,
    InvitationService,
    GuestService,
    MessageService,
    ConfirmationService,],
  bootstrap: [AppComponent]
})
export class AppModule { }
