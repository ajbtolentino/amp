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
import { MenubarModule } from 'primeng/menubar';
import { MenuModule } from 'primeng/menu';
import { ButtonModule } from 'primeng/button';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

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
    BrowserModule,
    AppRoutingModule,
    AuthConfigModule,
    MenubarModule,
    MenuModule,
    ButtonModule,
    BrowserModule,
    BrowserAnimationsModule
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
  )],
  bootstrap: [AppComponent]
})
export class AppModule { }
