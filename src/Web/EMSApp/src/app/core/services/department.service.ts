import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { DropDownModel } from '../models/common/drop.down.model';

@Injectable({
  providedIn: 'root',
})
export class DepartmentService {
  baseUrl = environment.emsAPIUrl;

  constructor(private _httpClient: HttpClient) {}
  async getDepartmentMasterData(): Promise<DropDownModel[]> {
    return await this._httpClient
      .get<DropDownModel[]>(`${this.baseUrl}Department/getDepartmentMasterData`)
      .toPromise();
  }
}
