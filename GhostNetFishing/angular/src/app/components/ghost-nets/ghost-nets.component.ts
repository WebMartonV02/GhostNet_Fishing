import { ListService, LocalizationService, PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subject, takeUntil } from 'rxjs';
import { GhostNetResultDto, GhostNetsService } from '../../proxy/ghost-nets';
import { ContextMenuActionModel } from '../../shared/context-menu/models/context-menu-action.model';
import { ContextMenuActionFactory } from '../../shared/context-menu/services/context-menu-action.factory';
import { CoordinatePosition } from '../../shared/models/coordinate-position.model';

@Component({
  selector: 'app-ghost-nets',
  templateUrl: './ghost-nets.component.html',
  styleUrls: ['./ghost-nets.component.scss'],
  providers: [ListService]
})
export class GhostNetsComponent implements OnInit, OnDestroy
{
  public ghostNets: PagedResultDto<GhostNetResultDto> = { items: [], totalCount: 0 } as PagedResultDto<GhostNetResultDto>;
  public isContextMenuOpened: boolean = false;
  public availableContextActions: Array<ContextMenuActionModel> = new Array<ContextMenuActionModel>();
  public coordinatePosition: CoordinatePosition = new CoordinatePosition();

  private _selectedElementByContextMenu: GhostNetResultDto;
  private _componentDestroyed$: Subject<void> = new Subject;

  constructor(
    public readonly listService: ListService,
    private _ghostNetsService: GhostNetsService,
    private _localizationService: LocalizationService) { }

  ngOnInit(): void
  {
    this.HookToDataTable();

    this.listService.getWithoutPageReset();

    this.InitiateContextMenu();
  }

  ngOnDestroy(): void
  {
    this._componentDestroyed$.next();
    this._componentDestroyed$.complete();
  }

  private HookToDataTable(): void
  {
    var listRequestDto: PagedAndSortedResultRequestDto = {} as PagedAndSortedResultRequestDto;

    const employeeStreamCreator = (query) => this._ghostNetsService.getList({ ...query, ...listRequestDto });

    this.listService.hookToQuery(employeeStreamCreator)
      .pipe(takeUntil(this._componentDestroyed$))
      .subscribe((payload: PagedResultDto<GhostNetResultDto>) =>
      {
        this.ghostNets = payload;
      });
  }

  public OnTableContextMenu(event): void
  {
    this.coordinatePosition.X = event.event.pageX;
    this.coordinatePosition.Y = event.event.pageY;
    this.isContextMenuOpened = true;

    this._selectedElementByContextMenu = event.content;

    event.event.preventDefault();
    event.event.stopPropagation();
  }

  private InitiateContextMenu(): void
  {
    this.availableContextActions.push(
      ContextMenuActionFactory.CreateAvailableContextActions(this._localizationService.instant('::'), (() => this.HookToDataTable()), "pen"),    // CreateEvents
      ContextMenuActionFactory.CreateAvailableContextActions(this._localizationService.instant('::'), (() => this.HookToDataTable()), "trash")); // CreateEvents
  }
}