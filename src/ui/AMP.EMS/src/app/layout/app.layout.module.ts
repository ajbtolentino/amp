import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule } from '@angular/router';
import { SharedModule } from '@modules/shared.module';
import { BadgeModule } from 'primeng/badge';
import { BreadcrumbModule } from 'primeng/breadcrumb';
import { ButtonModule } from 'primeng/button';
import { InputSwitchModule } from 'primeng/inputswitch';
import { InputTextModule } from 'primeng/inputtext';
import { MenubarModule } from 'primeng/menubar';
import { ProgressSpinnerModule } from 'primeng/progressspinner';
import { RadioButtonModule } from 'primeng/radiobutton';
import { RippleModule } from 'primeng/ripple';
import { SidebarModule } from 'primeng/sidebar';
import { UnauthorizedComponent } from "../pages/unauthorized/unauthorized.component";
import { BreadcrumbsComponent } from './breadcrumbs/app.breadcrumbs.component';
import { EventLayoutComponent } from './event-layout/event-layout.component';
import { EventMenuComponent } from './event-layout/event-menu.component';
import { EventMenuitemComponent } from './event-layout/event-menuitem.component';
import { EventSidebarComponent } from './event-layout/event-sidebar.component';
import { EventTopBarComponent } from './event-layout/event-topbar.component';
import { EventsLayoutComponent } from './events-layout/events-layout.component';
import { EventsTopBarComponent } from './events-layout/events-topbar.component';
import { FooterComponent } from './footer/app.footer.component';

@NgModule({
    declarations: [
        BreadcrumbsComponent,
        EventTopBarComponent,
        EventMenuComponent,
        EventMenuitemComponent,
        EventSidebarComponent,
        EventsTopBarComponent,
        EventLayoutComponent,
        EventsLayoutComponent,
        FooterComponent,
    ],
    imports: [
        SharedModule,
        ProgressSpinnerModule,
        BadgeModule,
        BrowserModule,
        BreadcrumbModule,
        BrowserAnimationsModule,
        ButtonModule,
        FormsModule,
        HttpClientModule,
        InputTextModule,
        InputSwitchModule,
        MenubarModule,
        RadioButtonModule,
        SidebarModule,
        RippleModule,
        RouterModule,
        UnauthorizedComponent
    ],
    exports: [EventLayoutComponent]
})
export class AppLayoutModule { }
