import type { GhostNetRequestDto, GhostNetResultDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class GhostNetsService {
  apiName = 'Default';
  

  create = (ghostNet: GhostNetRequestDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'POST',
      url: '/api/app/ghost-nets',
      body: ghostNet,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: number, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/ghost-nets/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: number, config?: Partial<Rest.Config>) =>
    this.restService.request<any, GhostNetResultDto>({
      method: 'GET',
      url: `/api/app/ghost-nets/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getList = (requestDto: PagedAndSortedResultRequestDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<GhostNetResultDto>>({
      method: 'GET',
      url: '/api/app/ghost-nets',
      params: { sorting: requestDto.sorting, skipCount: requestDto.skipCount, maxResultCount: requestDto.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  update = (ghostNet: GhostNetRequestDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'PUT',
      url: '/api/app/ghost-nets',
      body: ghostNet,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
