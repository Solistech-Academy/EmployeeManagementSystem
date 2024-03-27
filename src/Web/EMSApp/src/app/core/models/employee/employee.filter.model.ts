import { EmployeeStatus } from '../../enums/employee.status';

export class EmployeeFilterModel {
  name: string;
  departmentId: number;
  employeeStatus: EmployeeStatus;
  pageSize: number;
  currentPage: number;
}
