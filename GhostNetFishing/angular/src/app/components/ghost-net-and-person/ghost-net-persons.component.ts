import { ConfigStateService, CurrentUserDto, ListService, LocalizationService, PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subject, takeUntil } from 'rxjs';
import { GhostNetsAndPersonsService } from '../../proxy/ghost-nets';
import { GhostNetAndPersonResultDto } from '../../proxy/ghost-nets-and-persons';
import { ContextMenuActionModel } from '../../shared/context-menu/models/context-menu-action.model';
import { ContextMenuActionFactory } from '../../shared/context-menu/services/context-menu-action.factory';
import { CoordinatePosition } from '../../shared/models/coordinate-position.model';

@Component({
  selector: 'app-ghost-net-persons',
  templateUrl: './ghost-net-persons.component.html',
  styleUrls: ['./ghost-net-persons.component.scss'],
  providers: [ListService]
})
export class GhostNetPersonsComponent implements OnInit, OnDestroy
{
  public ghostNetPersons: PagedResultDto<GhostNetAndPersonResultDto> = { items: [], totalCount: 0 } as PagedResultDto<GhostNetAndPersonResultDto>;
  public isContextMenuOpened: boolean = false;
  public availableContextActions: Array<ContextMenuActionModel> = new Array<ContextMenuActionModel>();
  public coordinatePosition: CoordinatePosition = new CoordinatePosition();

  private _selectedElementByContextMenu: GhostNetAndPersonResultDto;
  private _componentDestroyed$: Subject<void> = new Subject;
  private _currentUserDto: CurrentUserDto;

  constructor(
    public readonly listService: ListService,
    private _ghostNetsAndPersonsService: GhostNetsAndPersonsService,
    private _localizationService: LocalizationService,
    private _configStateService: ConfigStateService) { }

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

    const streamCreator = (query) => this._ghostNetsAndPersonsService.getListWithUnassignedGhostNets({ ...query, ...listRequestDto });

    this.listService.hookToQuery(streamCreator)
      .pipe(takeUntil(this._componentDestroyed$))
      .subscribe((payload: PagedResultDto<GhostNetAndPersonResultDto>) =>
      {
        this.ghostNetPersons = payload;
      });
  }

  private AssignCurrentUserToGhostNet(): void
  {
    
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
      ContextMenuActionFactory.CreateAvailableContextActions(this._localizationService.instant('::Assign myself'), (() => this.AssignCurrentUserToGhostNet()), "pen")); // CreateEvents
  }
}
