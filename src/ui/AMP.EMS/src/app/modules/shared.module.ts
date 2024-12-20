import { DragDropModule } from '@angular/cdk/drag-drop';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AbsoluteValuePipe, FilterPipe, FindItemPipe, JsonParsePipe, MapPipe, OrderByPipe, ReducePipe, WithStatusPipe } from '@shared/pipes';
import { ButtonModule } from 'primeng/button';
import { CalendarModule } from 'primeng/calendar';
import { CardModule } from 'primeng/card';
import { ChartModule } from 'primeng/chart';
import { CheckboxModule } from 'primeng/checkbox';
import { DataViewModule } from 'primeng/dataview';
import { DialogModule } from 'primeng/dialog';
import { DropdownModule } from 'primeng/dropdown';
import { EditorModule } from 'primeng/editor';
import { FloatLabelModule } from 'primeng/floatlabel';
import { InputNumberModule } from 'primeng/inputnumber';
import { InputTextModule } from 'primeng/inputtext';
import { InputTextareaModule } from 'primeng/inputtextarea';
import { ListboxModule } from 'primeng/listbox';
import { MenuModule } from 'primeng/menu';
import { MessageModule } from 'primeng/message';
import { MessagesModule } from 'primeng/messages';
import { MultiSelectModule } from 'primeng/multiselect';
import { PanelModule } from 'primeng/panel';
import { ProgressSpinnerModule } from 'primeng/progressspinner';
import { RadioButtonModule } from 'primeng/radiobutton';
import { RippleModule } from 'primeng/ripple';
import { SkeletonModule } from 'primeng/skeleton';
import { StyleClassModule } from 'primeng/styleclass';
import { TableModule } from 'primeng/table';
import { TabViewModule } from 'primeng/tabview';
import { TimelineModule } from 'primeng/timeline';
import { ToggleButtonModule } from 'primeng/togglebutton';
import { ToolbarModule } from 'primeng/toolbar';
import { TooltipModule } from 'primeng/tooltip';
import { VerifyComponent } from './guest/verify/verify.component';

@NgModule({
  declarations: [
    WithStatusPipe,
    FindItemPipe,
    OrderByPipe,
    FilterPipe,
    AbsoluteValuePipe,
    ReducePipe,
    MapPipe,
    JsonParsePipe,
    VerifyComponent],
  imports: [
    CardModule,
    CommonModule,
    DragDropModule,
    ButtonModule,
    DialogModule,
    DropdownModule,
    EditorModule,
    FormsModule,
    FloatLabelModule,
    InputTextModule,
    InputTextareaModule,
    InputNumberModule,
    ListboxModule,
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
    RadioButtonModule,
    StyleClassModule,
    TimelineModule,
    ToggleButtonModule,
    PanelModule
  ],
  exports: [
    AbsoluteValuePipe,
    CardModule,
    DragDropModule,
    WithStatusPipe,
    FindItemPipe,
    OrderByPipe,
    FilterPipe,
    FloatLabelModule,
    ReducePipe,
    MapPipe,
    JsonParsePipe,
    CommonModule,
    ButtonModule,
    DataViewModule,
    DialogModule,
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
    RadioButtonModule,
    StyleClassModule,
    TimelineModule,
    PanelModule,
    ToggleButtonModule,
    ListboxModule,
  ]
})
export class SharedModule { }
