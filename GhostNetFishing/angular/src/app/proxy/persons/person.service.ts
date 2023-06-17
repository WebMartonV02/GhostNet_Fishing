import type { PersonRequestDto, PersonResultDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class PersonService {
  apiName = 'Default';
  

  create = (requestDto: PersonRequestDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'POST',
      url: '/api/app/person',
      body: requestDto,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: number, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/person/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: number, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PersonResultDto>({
      method: 'GET',
      url: `/api/app/person/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getList = (requestDto: PagedAndSortedResultRequestDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<PersonResultDto>>({
      method: 'GET',
      url: '/api/app/person',
      params: { sorting: requestDto.sorting, skipCount: requestDto.skipCount, maxResultCount: requestDto.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  update = (requestDto: PersonRequestDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'PUT',
      url: '/api/app/person',
      body: requestDto,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
