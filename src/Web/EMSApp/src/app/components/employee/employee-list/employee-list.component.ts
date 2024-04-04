import { Component } from '@angular/core';
import { DropDownModel } from './../../../core/models/common/drop.down.model';
import { EmployeeService } from '../../../core/services/employee.service';
import { EmployeeFilterModel } from '../../../core/models/employee/employee.filter.model';
import { EmployeeModel } from '../../../core/models/employee/employee.model';
import { TableLazyLoadEvent } from 'primeng/table';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
//import { MatDialog } from '@angular/material/dialog';
@Component({
	selector: 'app-employee-list',
	templateUrl: './employee-list.component.html',
	styleUrl: './employee-list.component.css',
})
export class EmployeeListComponent {
	//core data properties
	listOfDepartments: DropDownModel[];
	activeStatus: DropDownModel[];
	listOfEmployees: EmployeeModel[];
	totalRecordCount: number;

	//filter data properties
	name: string;
	departmentId: number = 0;
	employeeStatus: number = 1;
	pageSize: number = 20;
	currentPage: number = 0;

	constructor(private employeeService: EmployeeService, private router: Router, private toastr: ToastrService) {
		this.getEmployeeMasterData();
	}

	ngOnInit() {}

	formatDate(dateString) {
		const date = new Date(dateString);
		const year = date.getFullYear();
		const month = (date.getMonth() + 1).toString().padStart(2, '0');
		const day = date.getDate().toString().padStart(2, '0');
		return `${year}-${month}-${day}`;
	}

	loadEmployees(event: TableLazyLoadEvent) {
		console.log(event);
		this.currentPage = event.first / event.rows;

		this.pageSize = event.rows;
		this.getFilteredEmployees();
	}

	async getEmployeeMasterData(): Promise<void> {
		try {
			let response = await this.employeeService.getEmployeeMasterData();
			this.listOfDepartments = response.listOfDepartments;
			this.activeStatus = response.activeStatus;
		} catch (error) {}
	}
	async getFilteredEmployees(): Promise<void> {
		try {
			const filter: EmployeeFilterModel = {
				name: this.name === '' ? null : this.name,
				departmentId: this.departmentId,
				employeeStatus: this.employeeStatus,
				pageSize: this.pageSize,
				currentPage: this.currentPage,
			};

			let response = await this.employeeService.getEmployeeByFilter(filter);
			this.listOfEmployees = response.items;
			this.totalRecordCount = response.totalCount;
		} catch (error) {}
	}
	async deleteEmployee(id: number): Promise<void> {
		try {
			let response = await this.employeeService.deactivateEmployee(id);
			if (response.succeeded) {
				this.toastr.success(response.successMessage, 'Success');
				this.getFilteredEmployees();
			} else {
				response.errors.forEach((message) => {
					this.toastr.error(message, 'Error');
				});
			}
		} catch (error) {}
	}
	async navigateToAddEmployee() {
		this.router.navigateByUrl('/add');
	}
	async updateEmployee(id: number): Promise<void> {
		this.router.navigate(['edit', id]);
	}
}
