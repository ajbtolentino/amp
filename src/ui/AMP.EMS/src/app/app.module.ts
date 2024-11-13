import { provideHttpClient, withInterceptors, withInterceptorsFromDi } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { provideRouter, RouterOutlet, withEnabledBlockingInitialNavigation } from '@angular/router';
import { EventService } from '@core/services';
import { RsvpService } from '@core/services/rsvp.service';
import { EventGuestService, GuestInvitationService } from '@modules/event/guest';
import { EventGuestInvitationRSVPDateComponent, EventGuestInvitationRSVPFormComponent, EventGuestInvitationRSVPLabelComponent, EventInvitationService } from '@modules/event/invitation';
import { CodeEditorModule } from '@ngstack/code-editor';
import { authInterceptor, autoLoginPartialRoutesGuard } from 'angular-auth-oidc-client';
import { provideDynamicHooks } from 'ngx-dynamic-hooks';
import { ConfirmationService, MessageService } from 'primeng/api';
import { Button } from 'primeng/button';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { DividerModule } from 'primeng/divider';
import { Messages } from 'primeng/messages';
import { RadioButton } from 'primeng/radiobutton';
import { ToastModule } from 'primeng/toast';
import { AppComponent } from '../app/app.component';
import { AppLayoutModule } from '../app/layout/app.layout.module';
import { NotfoundComponent } from '../app/pages/notfound/notfound.component';
import { UnauthorizedComponent } from '../app/pages/unauthorized/unauthorized.component';
import { AuthConfigModule } from './core/auth-config.module';
import { apiResponseInterceptor } from './core/interceptors/api.response.interceptor';
import { EventLayoutComponent } from './layout/event-layout/event-layout.component';
import { EventsLayoutComponent } from './layout/events-layout/events-layout.component';
import { HomeComponent } from './pages/home/home.component';

@NgModule({
    imports: [
        AuthConfigModule,
        BrowserAnimationsModule,
        AppLayoutModule,
        DividerModule,
        ToastModule,
        RouterOutlet,
        ConfirmDialogModule,
        CodeEditorModule.forRoot(),
    ],
    providers: [
        provideHttpClient(withInterceptorsFromDi(), withInterceptors([authInterceptor(), apiResponseInterceptor])),
        provideDynamicHooks({
            parsers: [EventGuestInvitationRSVPFormComponent,
                EventGuestInvitationRSVPLabelComponent,
                EventGuestInvitationRSVPDateComponent,
                Button,
                RadioButton,
                Messages],
            options: {
                sanitize: false
            }
        }),
        provideRouter(
            [
                {
                    path: '',
                    pathMatch: 'full',
                    component: HomeComponent
                },
                {
                    path: 'events',
                    title: 'Events',
                    canActivate: [autoLoginPartialRoutesGuard],
                    component: EventsLayoutComponent,
                    loadChildren: () => import('@modules/events/events.module').then(m => m.EventsModule)
                },
                {
                    path: 'event/:eventId',
                    title: 'Event',
                    component: EventLayoutComponent,
                    canActivate: [autoLoginPartialRoutesGuard],
                    loadChildren: () => import('@modules/event/event.module').then(m => m.EventModule)
                },
                {
                    path: 'vendors',
                    component: EventsLayoutComponent,
                    canActivate: [autoLoginPartialRoutesGuard],
                    loadChildren: () => import('@modules/vendor/vendor.module').then(m => m.VendorModule)
                },
                {
                    path: 'invitation',
                    title: 'Invitation',
                    loadChildren: () => import('@modules/rsvp/rsvp.module').then(m => m.RsvpModule)
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
        GuestInvitationService,
        EventInvitationService,
        MessageService,
        ConfirmationService,
        RsvpService
    ],
    declarations: [AppComponent],
    bootstrap: [AppComponent]
})
export class AppModule { }
