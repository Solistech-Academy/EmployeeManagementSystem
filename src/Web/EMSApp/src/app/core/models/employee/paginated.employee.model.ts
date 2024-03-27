import { PaginatedListModel } from '../common/paginated.list.model';
import { EmployeeModel } from './employee.model';

export class PaginatedEmployeeModel extends PaginatedListModel {
  items: EmployeeModel[];
}
