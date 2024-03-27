import { Component } from '@angular/core';
import {
  FormControl,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  UntypedFormBuilder,
  UntypedFormGroup,
} from '@angular/forms';
import { EmployeeService } from './../../../core/services/employee.service';
import { FloatLabelModule } from 'primeng/floatlabel';
import { MultiSelectModule } from 'primeng/multiselect';
import { DepartmentService } from '../../../core/services/department.service';
import { DropDownModel } from '../../../core/models/common/drop.down.model';

@Component({
  selector: 'app-add-employee',
  standalone: true,
  templateUrl: './add-employee.component.html',
  styleUrls: ['./add-employee.component.css'],
  imports: [
    ReactiveFormsModule,
    FormsModule,
    FloatLabelModule,
    MultiSelectModule,
  ],
  providers: [EmployeeService, DepartmentService],
})
export class AddEmployeeComponent {
  employeeDetailForm: UntypedFormGroup;
  departments: DropDownModel[];
  constructor(
    private employeeService: EmployeeService,
    private untypedFormBuilder: UntypedFormBuilder,
    private departmentService: DepartmentService
  ) {}
  ngOnInit() {
    this.getDepartmentMasterData();
  }

  async getDepartmentMasterData(): Promise<void> {
    try {
      let response = await this.departmentService.getDepartmentMasterData();
      this.departments = response;
      await this.createEmployeeForm();
    } catch (error) {}
  }

  async createEmployeeForm(): Promise<void> {
    try {
      this.employeeDetailForm = this.untypedFormBuilder.group({
        id: [0],
        firstName: [''],
        lastName: [''],
        address: [''],
        mobileNumber: [''],
        email: [''],
        birthday: [new Date()],
        isActive: [true],
        departments: [[]],
      });
    } catch (error) {}
  }

  async saveEmployee() {
    try {
      const result = await this.employeeService.saveEmployee(
        this.employeeDetailForm.getRawValue()
      );
      console.log('Employee saved successfully:', result);
    } catch (error) {
      console.error('Error saving employee:', error);
    }
  }
}
