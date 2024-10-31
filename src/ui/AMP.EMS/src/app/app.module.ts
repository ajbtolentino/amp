import { AppComponent } from '../app/app.component';
import { MessageService, ConfirmationService } from 'primeng/api';
import { EventService } from '../app/core/services/event.service';
import { EventInvitationService as EventInvitationService } from './core/services/event-invitation.service';
import { provideHttpClient, withInterceptors, withInterceptorsFromDi } from '@angular/common/http';
import { provideRouter, RouterOutlet, withEnabledBlockingInitialNavigation } from '@angular/router';
import { authInterceptor, autoLoginPartialRoutesGuard, AuthModule, EventTypes, PublicEventsService, AbstractSecurityStorage, DefaultLocalStorageService } from 'angular-auth-oidc-client';
import { UnauthorizedComponent } from '../app/pages/unauthorized/unauthorized.component';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppLayoutModule } from '../app/layout/app.layout.module';
import { EventTypeService } from '../app/core/services/event-type.service';
import { EventsModule } from '../app/modules/events/events.module';
import { NotfoundComponent } from '../app/pages/notfound/notfound.component';
import { EventGuestInvitationRSVPFormComponent, EventGuestInvitationRSVPLabelComponent } from './modules/event/event-guest-invitation/event-guest-invitation-rsvp.component';
import { provideDynamicHooks } from 'ngx-dynamic-hooks';
import { CodeEditorModule } from '@ngstack/code-editor';

import { ConfirmDialogModule } from 'primeng/confirmdialog';

import { ToastModule } from 'primeng/toast';
import { DefaultComponent } from './modules/default/default.component';
import { apiResponseInterceptor } from './core/interceptors/api.response.interceptor';
import { Button } from 'primeng/button';
import { RadioButton } from 'primeng/radiobutton';
import { SharedModule } from './modules/shared.module';
import { EventGuestService } from './core/services/event-guest.service';
import { EventGuestInvitationService } from './core/services/event-guest-invitation.service';
import { RsvpService } from './core/services/rsvp.service';
import { DividerModule } from 'primeng/divider';
import { AuthConfigModule } from './core/auth-config.module';

@NgModule({
    imports: [
        AuthConfigModule,
        SharedModule,
        BrowserAnimationsModule,
        AppLayoutModule,
        DividerModule,
        EventsModule,
        ToastModule,
        RouterOutlet,
        ConfirmDialogModule,
        CodeEditorModule.forRoot(),
    ],
    providers: [
        provideHttpClient(withInterceptorsFromDi(), withInterceptors([authInterceptor(), apiResponseInterceptor])),
        provideDynamicHooks({
            parsers: [EventGuestInvitationRSVPFormComponent, EventGuestInvitationRSVPLabelComponent, Button, RadioButton],
            options: {
                sanitize: false
            }
        }),
        provideRouter(
            [
                {
                    path: '',
                    pathMatch: 'full',
                    component: DefaultComponent
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
        EventGuestService,
        EventGuestInvitationService,
        EventInvitationService,
        MessageService,
        ConfirmationService,
        RsvpService,
        EventTypeService
    ],
    declarations: [AppComponent],
    bootstrap: [AppComponent]
})
export class AppModule { }
