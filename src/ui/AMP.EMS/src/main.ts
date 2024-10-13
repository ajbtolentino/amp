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
import { EventDetailsComponent } from './app/modules/event-details/event-details.component';
import { EventListComponent } from './app/modules/event-list/event-list.component';
import { GuestListComponent } from './app/modules/guest-list/guest-list.component';
import { InvitationDetailsComponent } from './app/modules/invitation-details/invitation-details.component';
import { environment } from './environments/environment';
import { InvitationLayoutComponent } from './app/layout/invitation-layout/invitation-layout.component';
import { RsvpService } from './app/core/services/rsvp.service';
import { importProvidersFrom } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppLayoutComponent } from './app/layout/app.layout.component';
import { LayoutService } from './app/layout/service/app.layout.service';
import { AppLayoutModule } from './app/layout/app.layout.module';
import { AppConfigModule } from './app/layout/config/config.module';

bootstrapApplication(AppComponent, {
  providers: [
    importProvidersFrom([BrowserAnimationsModule, AppLayoutModule,]),
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
          component: AppLayoutComponent,
          children: [
            {
              path: 'events',
              title: 'Manage Events',
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
    RsvpService,
    LayoutService
  ]
}).catch(err => console.error(err));
