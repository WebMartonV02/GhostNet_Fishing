import { RestService, Rest } from '@abp/ng.core';
import type { PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { GhostNetAndPersonRequestDto, GhostNetAndPersonResultDto } from '../ghost-nets-and-persons/models';

@Injectable({
  providedIn: 'root',
})
export class GhostNetsAndPersonsService {
  apiName = 'Default';
  

  assignCurrentUserToTheSpecificGhostnNetByGhostNetId = (ghostNetId: number, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'POST',
      url: `/api/app/ghost-nets-and-persons/assign-current-user-to-the-specific-ghostn-net/${ghostNetId}`,
    },
    { apiName: this.apiName,...config });
  

  create = (requestDto: GhostNetAndPersonRequestDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'POST',
      url: '/api/app/ghost-nets-and-persons',
      body: requestDto,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: number, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/ghost-nets-and-persons/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: number, config?: Partial<Rest.Config>) =>
    this.restService.request<any, GhostNetAndPersonResultDto>({
      method: 'GET',
      url: `/api/app/ghost-nets-and-persons/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getListWithUnassignedGhostNets = (requestDto: PagedAndSortedResultRequestDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<GhostNetAndPersonResultDto>>({
      method: 'GET',
      url: '/api/app/ghost-nets-and-persons/with-unassigned-ghost-nets',
      params: { sorting: requestDto.sorting, skipCount: requestDto.skipCount, maxResultCount: requestDto.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  update = (requestDto: GhostNetAndPersonRequestDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'PUT',
      url: '/api/app/ghost-nets-and-persons',
      body: requestDto,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
