import type { GhostNetStatusResultDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class GhostNetStatusService {
  apiName = 'Default';
  

  getByGhostNetStatusId = (ghostNetStatusId: number, config?: Partial<Rest.Config>) =>
    this.restService.request<any, GhostNetStatusResultDto>({
      method: 'GET',
      url: '/api/app/ghost-net-status',
      params: { ghostNetStatusId },
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
