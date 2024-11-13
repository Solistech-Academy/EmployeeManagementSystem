import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment.development';
import { HttpClient, HttpParams } from '@angular/common/http';
import { EmployeeModel } from '../models/employee/employee.model';
import { ResultModel } from '../models/common/result.model';
import { EmployeeFilterModel } from '../models/employee/employee.filter.model';
import { PaginatedEmployeeModel } from '../models/employee/paginated.employee.model';
import { EmployeeMasterDataModel } from './../models/employee/employee.master.data.model';
import { firstValueFrom } from 'rxjs';

@Injectable({
	providedIn: 'root',
})
export class EmployeeService {
	baseUrl = environment.emsAPIUrl;

	constructor(private _httpClient: HttpClient) {}

	async saveEmployee(employee: EmployeeModel): Promise<ResultModel> {
		try {
			return await firstValueFrom(this._httpClient.post<ResultModel>(`${this.baseUrl}Employee/saveEmployee`, employee));
		} catch (error) {}
	}

	async getEmployeeById(id: number): Promise<EmployeeModel> {
		try {
			return await firstValueFrom(this._httpClient.get<EmployeeModel>(`${this.baseUrl}Employee/getEmployeeById/${id}`));
		} catch (error) {}
	}

	async deactivateEmployee(id: number): Promise<ResultModel> {
		try {
			return await firstValueFrom(
				this._httpClient.delete<ResultModel>(`${this.baseUrl}Employee/deactivateEmployee/${id}`)
			);
		} catch (error) {}
	}

	async getEmployeeByFilter(employeeFilter: EmployeeFilterModel): Promise<PaginatedEmployeeModel> {
		try {
			const params = new HttpParams()
				.set('Name', employeeFilter.name != undefined ? employeeFilter.name.toString() : '')
				.set('DepartmentId', employeeFilter.departmentId.toString())
				.set('EmployeeStatus', employeeFilter.employeeStatus.toString())
				.set('PageSize', employeeFilter.pageSize.toString())
				.set('CurrentPage', employeeFilter.currentPage.toString());
			return await firstValueFrom(
				this._httpClient.get<PaginatedEmployeeModel>(`${this.baseUrl}Employee/getEmployeeByFilter/`, { params })
			);
		} catch (error) {}
	}

	async validateMobileNumber(mobileNumber: String): Promise<Boolean> {
		try {
			return await firstValueFrom(
				this._httpClient.get<Boolean>(`${this.baseUrl}Employee/validateMobileNumber?mobileNumber=${mobileNumber}`)
			);
		} catch (error) {}
	}

	async validateEmail(email: String): Promise<Boolean> {
		try {
			return await firstValueFrom(
				this._httpClient.get<Boolean>(`${this.baseUrl}Employee/validateEmail?email=${email}`)
			);
		} catch (error) {}
	}
	async getEmployeeMasterData(): Promise<EmployeeMasterDataModel> {
		return await firstValueFrom(
			this._httpClient.get<EmployeeMasterDataModel>(`${this.baseUrl}Employee/getEmployeeMasterData`)
		);
	}
}
