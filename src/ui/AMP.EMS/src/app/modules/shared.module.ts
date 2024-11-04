import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ButtonModule } from 'primeng/button';
import { CalendarModule } from 'primeng/calendar';
import { ChartModule } from 'primeng/chart';
import { CheckboxModule } from 'primeng/checkbox';
import { DropdownModule } from 'primeng/dropdown';
import { InputNumberModule } from 'primeng/inputnumber';
import { InputTextModule } from 'primeng/inputtext';
import { InputTextareaModule } from 'primeng/inputtextarea';
import { MenuModule } from 'primeng/menu';
import { MultiSelectModule } from 'primeng/multiselect';
import { RippleModule } from 'primeng/ripple';
import { SkeletonModule } from 'primeng/skeleton';
import { TableModule } from 'primeng/table';
import { ToolbarModule } from 'primeng/toolbar';
import { TooltipModule } from 'primeng/tooltip';
import { TabViewModule } from 'primeng/tabview';
import { EditorModule } from 'primeng/editor';
import { DataViewModule } from 'primeng/dataview';
import { ProgressSpinnerModule } from 'primeng/progressspinner';
import { FilterPipe, FindItemPipe, OrderByPipe, WithStatusPipe } from '@shared/pipes';
import { MessagesModule } from 'primeng/messages';
import { MessageModule } from 'primeng/message';
import { RadioButtonModule } from 'primeng/radiobutton';

@NgModule({
  declarations: [WithStatusPipe, FindItemPipe, OrderByPipe, FilterPipe],
  imports: [
    CommonModule,
    ButtonModule,
    DropdownModule,
    EditorModule,
    FormsModule,
    InputTextModule,
    InputTextareaModule,
    InputNumberModule,
    MenuModule,
    MultiSelectModule,
    ChartModule,
    CheckboxModule,
    CalendarModule,
    DataViewModule,
    MessagesModule,
    MessageModule,
    ProgressSpinnerModule,
    TableModule,
    TooltipModule,
    RippleModule,
    ReactiveFormsModule,
    SkeletonModule,
    TabViewModule,
    ToolbarModule,
    RadioButtonModule
  ],
  exports: [
    WithStatusPipe,
    FindItemPipe,
    OrderByPipe,
    FilterPipe,
    CommonModule,
    ButtonModule,
    DataViewModule,
    DropdownModule,
    EditorModule,
    FormsModule,
    InputTextModule,
    MessagesModule,
    InputTextareaModule,
    InputNumberModule,
    MenuModule,
    MultiSelectModule,
    ChartModule,
    CheckboxModule,
    CalendarModule,
    DropdownModule,
    MessageModule,
    TableModule,
    TooltipModule,
    ProgressSpinnerModule,
    RippleModule,
    ReactiveFormsModule,
    SkeletonModule,
    TabViewModule,
    ToolbarModule,
    RadioButtonModule
  ]
})
export class SharedModule { }
