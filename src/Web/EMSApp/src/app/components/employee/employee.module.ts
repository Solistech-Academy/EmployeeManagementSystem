import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms'; // Import ReactiveFormsModule

import { EmployeeRoutingModule } from './employee-routing.module';
import { EmployeeComponent } from './employee.component';
import { FloatLabelModule } from 'primeng/floatlabel';
import { MultiSelectModule } from 'primeng/multiselect';
import { CalendarModule } from 'primeng/calendar';
import { InputTextModule } from 'primeng/inputtext';
import { TableModule } from 'primeng/table';
import { EmployeeListComponent } from './employee-list/employee-list.component';
import { DropdownModule } from 'primeng/dropdown';
import { ToolbarModule } from 'primeng/toolbar';
import { InputMaskModule } from 'primeng/inputmask';
import { ConfirmationDialogComponent } from './employee-list/confirmation-dialog/confirmation-dialog.component';
import { MatDialogModule } from '@angular/material/dialog';
import { ConfirmDialogModule } from 'primeng/confirmdialog';

import { ConfirmationService } from 'primeng/api';

@NgModule({
	declarations: [EmployeeComponent, EmployeeListComponent, ConfirmationDialogComponent],
	providers: [ConfirmationService],
	imports: [
		CommonModule,
		ReactiveFormsModule,
		FloatLabelModule,
		EmployeeRoutingModule,
		MultiSelectModule,
		FormsModule,
		CalendarModule,
		InputTextModule,
		TableModule,
		DropdownModule,
		ToolbarModule,
		InputMaskModule,
		MatDialogModule,
		ConfirmDialogModule,
	],
	exports: [EmployeeComponent],
})
export class EmployeeModule {}
