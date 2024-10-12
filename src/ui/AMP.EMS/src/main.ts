import { bootstrapApplication } from '@angular/platform-browser';
import { AppComponent } from './app/app.component';
import { MessageService, ConfirmationService } from 'primeng/api';
import { EventService } from './app/core/services/event.service';
import { GuestService } from './app/core/services/guest.service';
import { InvitationService } from './app/core/services/invitation.service';
import { provideHttpClient, withInterceptors } from '@angular/common/http';
import { provideRouter, withEnabledBlockingInitialNavigation } from '@angular/router';
import { authInterceptor, provideAuth, LogLevel, autoLoginPartialRoutesGuard } from 'angular-auth-oidc-client';
import { ForbiddenComponent } from './app/core/components/forbidden/forbidden.component';
import { UnauthorizedComponent } from './app/core/components/unauthorized/unauthorized.component';
import { EventDetailsComponent } from './app/features/event-details/event-details.component';
import { EventListComponent } from './app/features/event-list/event-list.component';
import { GuestListComponent } from './app/features/guest-list/guest-list.component';
import { InvitationDetailsComponent } from './app/features/invitation-details/invitation-details.component';
import { MainLayoutComponent } from './app/layout/main-layout/main-layout.component';
import { environment } from './environments/environment';
import { InvitationLayoutComponent } from './app/layout/invitation-layout/invitation-layout.component';
import { RsvpService } from './app/core/services/rsvp.service';
import { importProvidersFrom } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

bootstrapApplication(AppComponent, {
  providers: [
    importProvidersFrom([BrowserAnimationsModule]),
    provideHttpClient(withInterceptors([authInterceptor()])),
    provideAuth({
      config: {
        triggerAuthorizationResultEvent: true,
        forbiddenRoute: '/forbidden',
        unauthorizedRoute: '/unauthorized',
        logLevel: LogLevel.Debug,
        historyCleanupOff: false,
        authority: environment.IDP_AUTHORITY_HTTPS_URL,
        redirectUrl: window.location.origin,
        postLogoutRedirectUri: window.location.origin,
        clientId: environment.EMS_SPA_CLIENTID,
        scope: environment.EMS_SPA_CLIENTSCOPE,
        responseType: 'code',
        silentRenew: true,
        useRefreshToken: true,
      },
    }),
    provideRouter(
      [
        {
          path: '',
          title: 'EMS',
          component: MainLayoutComponent,
          children: [
            {
              path: 'events',
              title: 'Manage Events',
              component: EventListComponent,
              canActivate: [autoLoginPartialRoutesGuard],
              children: [
                {
                  path: ':id',
                  component: EventDetailsComponent,
                  canActivate: [autoLoginPartialRoutesGuard],
                },
              ]
            },
            {
              path: 'guests',
              title: 'Manage Guests',
              component: GuestListComponent,
              canActivate: [autoLoginPartialRoutesGuard],
            },
          ]
        },
        {
          path: '',
          title: 'Invitation',
          component: InvitationLayoutComponent,
          children: [
            {
              path: 'invitation',
              title: 'RSVP',
              children: [
                {
                  path: ':code',
                  title: 'Invitation',
                  component: InvitationDetailsComponent
                }
              ]
            }
          ]
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
        { path: '**', redirectTo: '' }
      ],
      withEnabledBlockingInitialNavigation()
    ),
    EventService,
    InvitationService,
    GuestService,
    MessageService,
    ConfirmationService,
    RsvpService
  ]
}).catch(err => console.error(err));
