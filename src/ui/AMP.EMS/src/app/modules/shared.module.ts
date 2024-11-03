import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WithStatusPipe } from '@shared/pipes/with-status';
import { FormsModule } from '@angular/forms';
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

@NgModule({
  declarations: [WithStatusPipe],
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
    DropdownModule,
    TableModule,
    TooltipModule,
    RippleModule,
    SkeletonModule,
    TabViewModule,
    ToolbarModule
  ],
  exports: [
    WithStatusPipe,
    CommonModule,
    ButtonModule,
    DataViewModule,
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
    DropdownModule,
    TableModule,
    TooltipModule,
    RippleModule,
    SkeletonModule,
    TabViewModule,
    ToolbarModule
  ]
})
export class SharedModule { }
