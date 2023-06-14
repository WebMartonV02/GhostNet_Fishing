import { ListService, PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subject, takeUntil } from 'rxjs';
import { GhostNetResultDto, GhostNetsService } from '../../proxy/ghost-nets';

@Component({
  selector: 'app-ghost-nets',
  templateUrl: './ghost-nets.component.html',
  styleUrls: ['./ghost-nets.component.scss'],
  providers: [ListService]
})
export class GhostNetsComponent implements OnInit, OnDestroy
{
  public ghostNets: PagedResultDto<GhostNetResultDto> = { items: [], totalCount: 0 } as PagedResultDto<GhostNetResultDto>;

  private _componentDestroyed$: Subject<void> = new Subject;

  constructor(
    public readonly listService: ListService,
    private _ghostNetsService: GhostNetsService) { }

  ngOnInit(): void
  {
    this.HookToDataTable();

    this.listService.getWithoutPageReset();
  }

  ngOnDestroy(): void
  {
    throw new Error('Method not implemented.');
  }

  private HookToDataTable(): void
  {
    var listRequestDto: PagedAndSortedResultRequestDto = {} as PagedAndSortedResultRequestDto;

    const employeeStreamCreator = (query) => this._ghostNetsService.getList({ ...query, ...listRequestDto });

    this.listService.hookToQuery(employeeStreamCreator)
      .pipe(takeUntil(this._componentDestroyed$))
      .subscribe((payload: PagedResultDto<GhostNetResultDto>) =>
      {
        console.log(payload)
        this.ghostNets = payload;
      });
  }

}
