import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HeaderComponent } from './components/shared/header/header.component';
import { AddEmployeeComponent } from './components/employee/add-employee/add-employee.component';
import { EmployeeService } from './core/services/employee.service';
import { DepartmentService } from './core/services/department.service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, HeaderComponent, AddEmployeeComponent],
  providers: [EmployeeService, DepartmentService],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent {
  title = 'EMSClientApp';
}
