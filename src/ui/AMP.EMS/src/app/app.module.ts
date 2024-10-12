// import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
// import { BrowserModule } from '@angular/platform-browser';

// import { AppRoutingModule } from './app-routing.module';
// import { AppComponent } from './app.component';
// import { AuthConfigModule } from './core/auth-config.module';
// import { UnauthorizedComponent } from './core/components/unauthorized/unauthorized.component';
// import { HomeComponent } from './core/components/home/home.component';
// import { ForbiddenComponent } from './core/components/forbidden/forbidden.component';
// import { NavigationComponent } from './layout/navigation/navigation.component';
// import { provideRouter, withEnabledBlockingInitialNavigation } from '@angular/router';
// import { authInterceptor, autoLoginPartialRoutesGuard, LogLevel, provideAuth } from 'angular-auth-oidc-client';
// import { provideHttpClient, withInterceptors } from '@angular/common/http';

// import { AvatarModule } from 'primeng/avatar';
// import { AvatarGroupModule } from 'primeng/avatargroup';
// import { ButtonModule } from 'primeng/button';
// import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
// import { CalendarModule } from 'primeng/calendar';
// import { ContextMenuModule } from 'primeng/contextmenu';
// import { ConfirmDialogModule } from 'primeng/confirmdialog';
// import { DataViewModule } from 'primeng/dataview';
// import { DialogModule } from 'primeng/dialog';
// import { DropdownModule } from 'primeng/dropdown';
// import { ProgressBarModule } from 'primeng/progressbar';
// import { InputTextModule } from 'primeng/inputtext';
// import { InputNumberModule } from 'primeng/inputnumber';
// import { MenubarModule } from 'primeng/menubar';
// import { MenuModule } from 'primeng/menu';
// import { MultiSelectModule } from 'primeng/multiselect';
// import { RadioButtonModule } from 'primeng/radiobutton';
// import { ToastModule } from 'primeng/toast';
// import { TableModule } from 'primeng/table';
// import { ToolbarModule } from 'primeng/toolbar';

// import { MessageService, ConfirmationService } from 'primeng/api';
// import { EventService } from './core/services/event.service';
// import { FormsModule } from '@angular/forms';
// import { EventDetailsComponent } from './features/event-details/event-details.component';
// import { EventListComponent } from './features/event-list/event-list.component';
// import { InvitationDetailsComponent } from './features/invitation-details/invitation-details.component';
// import { InvitationService } from './core/services/invitation.service';
// import { GuestListComponent } from './features/guest-list/guest-list.component';
// import { GuestService } from './core/services/guest.service';

// import { environment } from './../environments/environment';
// import { CommonModule } from '@angular/common';
// import { MainLayoutComponent } from './layout/main-layout/main-layout.component';
// import { InvitationLayoutComponent } from './layout/invitation-layout/invitation-layout.component';

// @NgModule({
//   declarations: [
//   ],
//   schemas: [CUSTOM_ELEMENTS_SCHEMA],
//   imports: [
//     AvatarModule,
//     AvatarGroupModule,
//     AppRoutingModule,
//     AuthConfigModule,
//     ButtonModule,
//     BrowserModule,
//     BrowserAnimationsModule,
//     BrowserModule,
//     CalendarModule,
//     CommonModule,
//     ContextMenuModule,
//     ConfirmDialogModule,
//     DataViewModule,
//     DialogModule,
//     DropdownModule,
//     FormsModule,
//     InputTextModule,
//     InputNumberModule,
//     MenubarModule,
//     MenuModule,
//     MultiSelectModule,
//     ProgressBarModule,
//     RadioButtonModule,
//     TableModule,
//     ToastModule,
//     ToolbarModule
//   ],
//   providers: [provideHttpClient(withInterceptors([authInterceptor()])),
//   provideAuth({
//     config: {
//       triggerAuthorizationResultEvent: true,
//       forbiddenRoute: '/forbidden',
//       unauthorizedRoute: '/unauthorized',
//       logLevel: LogLevel.Debug,
//       historyCleanupOff: false,
//       authority: environment.IDP_AUTHORITY_HTTPS_URL,
//       redirectUrl: window.location.origin,
//       postLogoutRedirectUri: window.location.origin,
//       clientId: environment.EMS_SPA_CLIENTID,
//       scope: environment.EMS_SPA_CLIENTSCOPE,
//       responseType: 'code',
//       silentRenew: true,
//       useRefreshToken: true,
//     },
//   }),
//   provideRouter(
//     [
//       {
//         path: '',
//         title: 'EMS',
//         component: MainLayoutComponent,
//         children: [
//           {
//             path: 'events',
//             title: 'EMS - Manage Events',
//             component: EventListComponent,
//             canActivate: [autoLoginPartialRoutesGuard],
//             children: [
//               {
//                 path: ':id',
//                 component: EventDetailsComponent,
//                 canActivate: [autoLoginPartialRoutesGuard],
//               },
//             ]
//           },
//           {
//             path: 'guests',
//             title: 'EMS - Manage Guests',
//             component: GuestListComponent,
//             canActivate: [autoLoginPartialRoutesGuard],
//           },
//         ]
//       },
//       {
//         path: 'invitation',
//         component: InvitationLayoutComponent,
//         children: [
//           {
//             path: '/:code',
//             title: 'Invitation',
//             component: InvitationDetailsComponent
//           }
//         ]
//       },
//       {
//         path: 'forbidden',
//         component: ForbiddenComponent,
//         canActivate: [autoLoginPartialRoutesGuard],
//       },
//       {
//         path: 'unauthorized',
//         component: UnauthorizedComponent
//       },
//     ],
//     withEnabledBlockingInitialNavigation()
//   ),
//     EventService,
//     InvitationService,
//     GuestService,
//     MessageService,
//     ConfirmationService,],
//   bootstrap: []
// })
// export class AppModule { }
