import { ListService, LocalizationService, PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subject, takeUntil } from 'rxjs';
import { PersonResultDto, PersonService } from '../../proxy/persons';
import { ContextMenuActionModel } from '../../shared/context-menu/models/context-menu-action.model';
import { ContextMenuActionFactory } from '../../shared/context-menu/services/context-menu-action.factory';
import { CoordinatePosition } from '../../shared/models/coordinate-position.model';

@Component({
  selector: 'app-persons',
  templateUrl: './persons.component.html',
  styleUrls: ['./persons.component.scss'],
  providers: [ListService]
})
export class PersonsComponent implements OnInit, OnDestroy
{
  public persons: PagedResultDto<PersonResultDto> = { items: [], totalCount: 0 } as PagedResultDto<PersonResultDto>;
  public isContextMenuOpened: boolean = false;
  public availableContextActions: Array<ContextMenuActionModel> = new Array<ContextMenuActionModel>();
  public coordinatePosition: CoordinatePosition = new CoordinatePosition();

  private _selectedElementByContextMenu: PersonResultDto;
  private _componentDestroyed$: Subject<void> = new Subject;

  constructor(
    public readonly listService: ListService,
    private _personService: PersonService,
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

    const streamCreator = (query) => this._personService.getList({ ...query, ...listRequestDto });

    this.listService.hookToQuery(streamCreator)
      .pipe(takeUntil(this._componentDestroyed$))
      .subscribe((payload: PagedResultDto<PersonResultDto>) =>
      {
        this.persons = payload;
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
