import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './components/shared/header/header.component';
import { AppLayoutComponent } from './components/shared/app-layout/app-layout.component';
import { FooterComponent } from './components/shared/footer/footer.component';
import { EmployeeModule } from './components/employee/employee.module';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { ToolbarModule } from 'primeng/toolbar';
import { ButtonModule } from 'primeng/button';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';

@NgModule({
	declarations: [AppComponent, AppLayoutComponent, HeaderComponent, FooterComponent],
	imports: [
		BrowserModule,
		AppRoutingModule,
		EmployeeModule,
		HttpClientModule,
		BrowserAnimationsModule,
		ToastrModule.forRoot(),
		ToolbarModule,
		ButtonModule,
	],
	providers: [provideAnimationsAsync()],
	bootstrap: [AppComponent],
})
export class AppModule {}
