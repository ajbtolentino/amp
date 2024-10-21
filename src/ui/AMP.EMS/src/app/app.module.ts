import { AppComponent } from '../app/app.component';
import { MessageService, ConfirmationService } from 'primeng/api';
import { EventService } from '../app/core/services/event.service';
import { EventGuestService } from './core/services/event-guest.service';
import { EventInvitationService as EventInvitationService } from '../app/core/services/event-invitation.service';
import { provideHttpClient, withInterceptors } from '@angular/common/http';
import { provideRouter, RouterOutlet, withEnabledBlockingInitialNavigation } from '@angular/router';
import { authInterceptor, provideAuth, LogLevel, autoLoginPartialRoutesGuard } from 'angular-auth-oidc-client';
import { UnauthorizedComponent } from '../app/pages/unauthorized/unauthorized.component';
import { environment } from '../environments/environment';
import { RsvpService } from '../app/core/services/rsvp.service';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppLayoutModule } from '../app/layout/app.layout.module';
import { EventTypeService } from '../app/core/services/event-type.service';
import { EventsModule } from '../app/modules/events/events.module';
import { NotfoundComponent } from '../app/pages/notfound/notfound.component';
import { EventsLayoutComponent } from '../app/layout/events-layout/events-layout.component';
import { EventGuestInvitationService } from '../app/core/services/event-guest-invitation.service';
import { EventGuestInvitationRSVPFormComponent, EventGuestInvitationRSVPLabelComponent } from './modules/event/event-invitation/event-guest-invitation-rsvp.component';
import { provideDynamicHooks } from 'ngx-dynamic-hooks';
import { CodeEditorModule } from '@ngstack/code-editor';

import { ConfirmDialogModule } from 'primeng/confirmdialog';

import { ToastModule } from 'primeng/toast';
import { DefaultComponent } from './modules/default/default.component';
import { responseInterceptor } from './core/interceptors/response.interceptor';

@NgModule({
    imports: [
        BrowserAnimationsModule,
        AppLayoutModule,
        EventsModule,
        ToastModule,
        RouterOutlet,
        ConfirmDialogModule,
        CodeEditorModule.forRoot(),
    ],
    providers: [
        provideHttpClient(withInterceptors([authInterceptor(), responseInterceptor])),
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
        provideDynamicHooks({
            parsers: [EventGuestInvitationRSVPFormComponent, EventGuestInvitationRSVPLabelComponent],
            options: {
                sanitize: false
            }
        }),
        provideRouter(
            [
                {
                    path: '',
                    pathMatch: 'full',
                    component: EventsLayoutComponent,
                    children: [
                        {
                            path: '',
                            component: DefaultComponent
                        }
                    ]
                },
                {
                    path: '',
                    title: 'Events',
                    loadChildren: () => import('../app/modules/events/events.module').then(m => m.EventsModule)
                },
                {
                    path: 'event',
                    title: 'Event',
                    canActivate: [autoLoginPartialRoutesGuard],
                    loadChildren: () => import('../app/modules/event/event.module').then(m => m.EventModule)
                },
                {
                    path: 'invitation',
                    title: 'Invitation',
                    loadChildren: () => import('../app/modules/guests/guests.module').then(m => m.GuestModule)
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
        EventInvitationService,
        EventGuestInvitationService,
        EventGuestService,
        MessageService,
        ConfirmationService,
        RsvpService,
        EventTypeService,
    ],
    declarations: [AppComponent],
    bootstrap: [AppComponent]
})
export class AppModule { }
