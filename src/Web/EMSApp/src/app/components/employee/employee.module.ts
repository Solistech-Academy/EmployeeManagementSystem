import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms'; // Import ReactiveFormsModule

import { EmployeeRoutingModule } from './employee-routing.module';
import { EmployeeComponent } from './employee.component';
import { FloatLabelModule } from 'primeng/floatlabel';
import { MultiSelectModule } from 'primeng/multiselect';
import { CalendarModule } from 'primeng/calendar';
import { InputTextModule } from 'primeng/inputtext';

@NgModule({
  declarations: [EmployeeComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FloatLabelModule,
    EmployeeRoutingModule,
    MultiSelectModule,
    FormsModule,
    CalendarModule,
    InputTextModule,
  ],
  exports: [EmployeeComponent],
})
export class EmployeeModule {}
