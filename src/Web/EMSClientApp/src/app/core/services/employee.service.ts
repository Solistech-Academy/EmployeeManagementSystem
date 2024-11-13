import { EmployeeFilterModel } from './../models/employee/employee.filter.model';
import { EmployeeModel } from './../models/employee/employee.model';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment.development';
import { ResultModel } from '../models/common/result.model';
import { PaginatedEmployeeModel } from '../models/employee/paginated.employee.model';

@Injectable({
  providedIn: 'root',
})
export class EmployeeService {
  baseUrl = environment.emsAPIUrl;

  constructor(private _httpClient: HttpClient) {}

  async saveEmployee(employee: EmployeeModel): Promise<ResultModel> {
    try {
      return await this._httpClient
        .post<ResultModel>(`${this.baseUrl}Employee/saveEmployee`, employee)
        .toPromise();
    } catch (error) {}
  }

  async getEmployeeById(id: number): Promise<EmployeeModel> {
    try {
      return await this._httpClient
        .get<EmployeeModel>(`${this.baseUrl}Employee/getEmployeeById/${id}`)
        .toPromise();
    } catch (error) {}
  }

  async deactivateEmployee(id: number): Promise<ResultModel> {
    try {
      return await this._httpClient
        .delete<ResultModel>(`${this.baseUrl}Employee/deactivateEmployee/${id}`)
        .toPromise();
    } catch (error) {}
  }

  async getEmployeeByFilter(
    employeeFilter: EmployeeFilterModel
  ): Promise<PaginatedEmployeeModel> {
    try {
      const params = new HttpParams()
        .set('Name', employeeFilter.name.toString())
        .set('DepartmentId', employeeFilter.departmentId.toString())
        .set('EmployeeStatus', employeeFilter.employeeStatus.toString())
        .set('PageSize', employeeFilter.pageSize.toString())
        .set('CurrentPage', employeeFilter.currentPage.toString());
      return await this._httpClient
        .get<PaginatedEmployeeModel>(
          `${this.baseUrl}Employee/getEmployeeByFilter/`,
          { params }
        )
        .toPromise();
    } catch (error) {}
  }
}
