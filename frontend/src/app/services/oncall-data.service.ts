import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { OnCallDeveloperResponseModel } from '../models/oncalldeveloper';
@Injectable()

export class OnCallDataService {
  constructor(private readonly client: HttpClient) {}

    getCurrentHelpInformation(): Observable<OnCallDeveloperResponseModel> {
        return this.client.get<OnCallDeveloperResponseModel>(environment.onCallApi + 'oncalldeveloper');
    }
}