import { provideHttpClient, withInterceptors, withInterceptorsFromDi } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { provideRouter, RouterOutlet, withEnabledBlockingInitialNavigation } from '@angular/router';
import { apiResponseInterceptor, dateInterceptor } from '@core/interceptors';
import { RsvpService } from '@core/services/rsvp.service';
import { EventGuestInvitationRSVPChangeableLabelComponent, EventGuestInvitationRSVPDateComponent, EventGuestInvitationRSVPFormComponent, EventGuestInvitationRSVPLabelComponent, EventGuestInvitationRSVPPluralizeLabelComponent } from '@modules/event';
import { VerifyComponent } from '@modules/guest/verify/verify.component';
import { SharedModule } from '@modules/shared.module';
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
import { UnauthorizedComponent } from '../app/pages/unauthorized/unauthorized.component';
import { AuthConfigModule } from './core/auth-config.module';
import { EventsLayoutComponent } from './layout/events-layout/events-layout.component';
import { ErrorComponent } from './pages/error/error.component';
import { HomeComponent } from './pages/home/home.component';

@NgModule({
    imports: [
        AuthConfigModule,
        BrowserAnimationsModule,
        AppLayoutModule,
        DividerModule,
        ToastModule,
        RouterOutlet,
        SharedModule,
        ConfirmDialogModule,
        CodeEditorModule.forRoot(),
    ],
    providers: [
        provideHttpClient(withInterceptorsFromDi(), withInterceptors([authInterceptor(), apiResponseInterceptor, dateInterceptor])),
        provideDynamicHooks({
            parsers: [EventGuestInvitationRSVPFormComponent,
                EventGuestInvitationRSVPLabelComponent,
                EventGuestInvitationRSVPDateComponent,
                EventGuestInvitationRSVPPluralizeLabelComponent,
                EventGuestInvitationRSVPChangeableLabelComponent,
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
                    path: 'guest/verify',
                    component: VerifyComponent
                },
                {
                    path: 'settings',
                    canActivate: [autoLoginPartialRoutesGuard],
                    component: EventsLayoutComponent,
                    loadChildren: () => import('@modules/settings/settings.module').then(m => m.SettingsModule)
                },
                {
                    path: 'unauthorized',
                    component: UnauthorizedComponent
                },
                {
                    path: 'error',
                    component: ErrorComponent
                },
                // { path: 'notfound', component: NotfoundComponent },
                // { path: '**', redirectTo: '/notfound' },
            ],
            withEnabledBlockingInitialNavigation()
        ),
        MessageService,
        ConfirmationService,
        RsvpService
    ],
    declarations: [AppComponent, HomeComponent],
    bootstrap: [AppComponent]
})
export class AppModule { }
