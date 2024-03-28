import { Component } from '@angular/core';
import {
  AbstractControl,
  UntypedFormBuilder,
  UntypedFormGroup,
  Validators,
} from '@angular/forms';
import { DropDownModel } from '../../core/models/common/drop.down.model';
import { EmployeeService } from '../../core/services/employee.service';
import { DepartmentService } from '../../core/services/department.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrl: './employee.component.css',
})
export class EmployeeComponent {
  employeeDetailForm: UntypedFormGroup;
  departments: DropDownModel[];
  constructor(
    private employeeService: EmployeeService,
    private untypedFormBuilder: UntypedFormBuilder,
    private departmentService: DepartmentService,
    private toastr: ToastrService
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

  async validatePhoneNumber() {
    try {
      if (this.mobileNumberFormControl.value) {
        let response = await this.employeeService.validateMobileNumber(
          this.mobileNumberFormControl.value
        );
        console.log(response);
        if (response) {
          this.mobileNumberFormControl.setErrors({
            isExist: true,
            required: false,
          });
        } else {
          this.mobileNumberFormControl.setErrors(null);
        }
      } else {
        this.mobileNumberFormControl.setErrors({ required: false });
      }
    } catch (error) {}
  }
  async validateEmail() {
    try {
      if (this.emailFormControl.value) {
        let response = await this.employeeService.validateEmail(
          this.emailFormControl.value
        );
        if (response) {
          this.emailFormControl.setErrors({ isExist: true, required: false });
        } else {
          this.emailFormControl.setErrors(null);
        }
      } else {
        this.emailFormControl.setErrors({ required: false });
      }
    } catch (error) {}
  }

  async createEmployeeForm(): Promise<void> {
    try {
      this.employeeDetailForm = this.untypedFormBuilder.group({
        id: [0],
        firstName: ['', [Validators.required]],
        lastName: ['', [Validators.required]],
        address: ['', [Validators.required]],
        mobileNumber: ['', [Validators.required]],
        email: ['', [Validators.required, Validators.email]],
        birthday: [new Date(), [Validators.required]],
        isActive: [true],
        departments: [[], [Validators.required]],
      });
    } catch (error) {}
  }
  async saveEmployee() {
    try {
      const result = await this.employeeService.saveEmployee(
        this.employeeDetailForm.getRawValue()
      );
      this.toastr.success('Employee saved successfully', 'Success');
      console.log('Employee saved successfully:', result);
    } catch (error) {
      console.error('Error saving employee:', error);
    }
  }

  get emailFormControl(): AbstractControl {
    return this.employeeDetailForm.get('email');
  }
  get mobileNumberFormControl(): AbstractControl {
    return this.employeeDetailForm.get('mobileNumber');
  }
}
