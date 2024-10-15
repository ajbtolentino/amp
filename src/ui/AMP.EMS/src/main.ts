import { bootstrapApplication } from '@angular/platform-browser';
import { AppComponent } from './app/app.component';
import { MessageService, ConfirmationService } from 'primeng/api';
import { EventService } from './app/core/services/event.service';
import { GuestService } from './app/core/services/guest.service';
import { InvitationService } from './app/core/services/event-invitation.service';
import { provideHttpClient, withInterceptors } from '@angular/common/http';
import { provideRouter, withEnabledBlockingInitialNavigation } from '@angular/router';
import { authInterceptor, provideAuth, LogLevel, autoLoginPartialRoutesGuard } from 'angular-auth-oidc-client';
import { UnauthorizedComponent } from './app/pages/unauthorized/unauthorized.component';
import { environment } from './environments/environment';
import { RsvpService } from './app/core/services/rsvp.service';
import { importProvidersFrom } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppLayoutModule } from './app/layout/app.layout.module';
import { EventTypeService } from './app/core/services/event-type.service';
import { AdminModule } from './app/modules/admin/admin.module';
import { NotfoundComponent } from './app/pages/notfound/notfound.component';

bootstrapApplication(AppComponent, {
  providers: [
    importProvidersFrom([BrowserAnimationsModule, AppLayoutModule, AdminModule]),
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
          loadChildren: () => import('./app/modules/admin/admin.module').then(m => m.AdminModule)
        },
        {
          path: '',
          title: 'Invitation',
          loadChildren: () => import('./app/modules/guests/guests.module').then(m => m.GuestModule)
        },
        {
          path: 'unauthorized',
          component: UnauthorizedComponent
        },
        { path: 'notfound', component: NotfoundComponent },
        { path: '**', redirectTo: '/notfound' },
      ],
      withEnabledBlockingInitialNavigation()
    ),
    EventService,
    InvitationService,
    GuestService,
    MessageService,
    ConfirmationService,
    RsvpService,
    EventTypeService
  ]
}).catch(err => console.error(err));
