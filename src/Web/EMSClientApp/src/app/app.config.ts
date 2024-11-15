import { ApplicationConfig } from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';
import { HeaderComponent } from './components/shared/header/header.component';
import { HttpClientModule, provideHttpClient } from '@angular/common/http';


export const appConfig: ApplicationConfig = {
  providers: [provideRouter(routes), HeaderComponent, provideHttpClient()],
};
