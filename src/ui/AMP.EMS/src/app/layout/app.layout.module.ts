import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { InputTextModule } from 'primeng/inputtext';
import { SidebarModule } from 'primeng/sidebar';
import { BadgeModule } from 'primeng/badge';
import { RadioButtonModule } from 'primeng/radiobutton';
import { InputSwitchModule } from 'primeng/inputswitch';
import { RippleModule } from 'primeng/ripple';
import { RouterModule } from '@angular/router';
import { EventTopBarComponent } from './event-layout/event-topbar.component';
import { FooterComponent } from './footer/app.footer.component';
import { BreadcrumbModule } from 'primeng/breadcrumb';
import { BreadcrumbsComponent } from './breadcrumbs/app.breadcrumbs.component';
import { EventLayoutComponent } from './event-layout/event-layout.component';
import { EventsLayoutComponent } from './events-layout/events-layout.component';
import { EventMenuComponent } from './event-layout/event-menu.component';
import { EventMenuitemComponent } from './event-layout/event-menuitem.component';
import { EventSidebarComponent } from './event-layout/event-sidebar.component';
import { EventsTopBarComponent } from './events-layout/events-topbar.component';
import { CodeEditorModule } from '@ngstack/code-editor';

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
        BadgeModule,
        BrowserModule,
        BreadcrumbModule,
        BrowserAnimationsModule,
        FormsModule,
        HttpClientModule,
        InputTextModule,
        InputSwitchModule,
        RadioButtonModule,
        SidebarModule,
        RippleModule,
        RouterModule,
    ],
})
export class AppLayoutModule { }
