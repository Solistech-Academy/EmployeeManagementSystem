import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmployeeComponent } from './components/employee/employee.component';
import { EmployeeListComponent } from './components/employee/employee-list/employee-list.component';

const routes: Routes = [
	{ path: 'add', component: EmployeeComponent },
	{ path: '', component: EmployeeListComponent },
];

@NgModule({
	imports: [RouterModule.forRoot(routes)],
	exports: [RouterModule],
})
export class AppRoutingModule {}
