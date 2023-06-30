import { ListService, LocalizationService, PagedAndSortedResultRequestDto, PagedResultDto, PermissionService } from '@abp/ng.core';
import { ToasterService } from '@abp/ng.theme.shared';
import { Component, HostListener, OnDestroy, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Subject, takeUntil } from 'rxjs';
import { GhostNetStatusService } from '../../../../proxy/ghost-net-statuses';
import { GhostNetResultDto, GhostNetsService } from '../../../../proxy/ghost-nets';
import { EventTypeConsts } from '../../../../shared/constants/event-type-constants.model';
import { ContextMenuActionModel } from '../../../../shared/context-menu/models/context-menu-action.model';
import { ContextMenuActionFactory } from '../../../../shared/context-menu/services/context-menu-action.factory';
import { CoordinatePosition } from '../../../../shared/models/coordinate-position.model';
import { GhostNetRequestDtoFactory } from '../../factories/ghost-net-request-dto.factory';
import { GhostNetStatusEnum } from '../../models/ghost-net-status-enum.model';
import { GhostNetDetailsComponent } from '../ghost-net-details/ghost-net-details.component';

@Component({
  selector: 'app-ghost-nets',
  templateUrl: './ghost-nets.component.html',
  styleUrls: ['./ghost-nets.component.scss'],
  providers: [ListService, GhostNetRequestDtoFactory]
})
export class GhostNetsComponent implements OnInit, OnDestroy
{
  public ghostNets: PagedResultDto<GhostNetResultDto> = { items: [], totalCount: 0 } as PagedResultDto<GhostNetResultDto>;
  public isContextMenuOpened: boolean = false;
  public availableContextActions: Array<ContextMenuActionModel> = new Array<ContextMenuActionModel>();
  public coordinatePosition: CoordinatePosition = new CoordinatePosition();

  private _selectedElementByContextMenu: GhostNetResultDto = {} as GhostNetResultDto;
  private _componentDestroyed$: Subject<void> = new Subject;

  constructor(
    public readonly listService: ListService,
    private _ghostNetsService: GhostNetsService,
    private _toasterService: ToasterService,
    private _ghostNetModalService: NgbModal,
    private _ghostNetStatusService: GhostNetStatusService,
    private _ghostNetRequestDtoFactory: GhostNetRequestDtoFactory,
    private _localizationService: LocalizationService,
    private _permissionService: PermissionService) { }

  ngOnInit(): void
  {
    this.HookToDataTable();

    this.listService.getWithoutPageReset();

    this.InitiateContextMenu();

    this._permissionService.getGrantedPolicy$("GhostNetFishing.GhostNet.Recovering")
      .pipe(takeUntil(this._componentDestroyed$))
      .subscribe((payload: boolean) =>
      {
        console.log(payload);
      })
  }

  ngOnDestroy(): void
  {
    this._componentDestroyed$.next();
    this._componentDestroyed$.complete();
  }

  @HostListener('document:click', ['$event'])
  public ClickedOutside($event): void
  {
    if ($event.target.className !== 'dropdown-item context-menu')
    {
      this.isContextMenuOpened = false;
    }
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

  public DataTableOnActivate(event: any): void
  {
    if (event.type == EventTypeConsts.DOUBLE_CLICK_EVENT)
    {
      this.ShowEditGhostNetModal(event.row.id);
    }
  }

  public ShowCreateGhostNetModal(): void
  {
    const modalRef = this._ghostNetModalService.open(GhostNetDetailsComponent, { size: 'xl' });

    modalRef.result.then(() =>
    {
      this._toasterService.success('::Successful');
    },
      error =>
      {
        this._toasterService.error('::Unsuccessful');
      })
      .finally(() =>
      {
        this.listService.getWithoutPageReset();
      });
  }

  private ShowEditGhostNetModal(ghostNetId: number): void
  {
    this._ghostNetsService.get(ghostNetId)
      .subscribe((ghostNet) =>
      {
        this._selectedElementByContextMenu = ghostNet;

        const modalRef = this._ghostNetModalService.open(GhostNetDetailsComponent, { size: 'xl' });
        modalRef.componentInstance.selectedGhostNet = ghostNet;

        modalRef.result.then(() =>
        {
          this._toasterService.success('::Successful');
        },
          error =>
          {
            this._toasterService.error('::Unsuccessful');
          })
          .finally(() =>
          {
            this.listService.getWithoutPageReset();
          });
      });
  }

  private HookToDataTable(): void
  {
    var listRequestDto: PagedAndSortedResultRequestDto = {} as PagedAndSortedResultRequestDto;

    const streamCreator = (query) => this._ghostNetsService.getList({ ...query, ...listRequestDto });

    this.listService.hookToQuery(streamCreator)
      .pipe(takeUntil(this._componentDestroyed$))
      .subscribe((payload: PagedResultDto<GhostNetResultDto>) =>
      {
        this.ghostNets = payload;
      });
  }

  private SetStatusToGemeldet(): void
  {
    let selectedGhostItem = this._selectedElementByContextMenu;

    let updatedGhostNet = this._ghostNetRequestDtoFactory.Create(selectedGhostItem, GhostNetStatusEnum.Gemeldet);

    this._ghostNetsService.update(updatedGhostNet).pipe(takeUntil(this._componentDestroyed$)).subscribe();

    this.listService.getWithoutPageReset();
  }

  private SetStatusToBergungBevorstehend(): void
  {
    let selectedGhostItem = this._selectedElementByContextMenu;

    let updatedGhostNet = this._ghostNetRequestDtoFactory.Create(selectedGhostItem, GhostNetStatusEnum.BergungBevorstehend);
    console.log(updatedGhostNet)
    this._ghostNetsService.update(updatedGhostNet).pipe(takeUntil(this._componentDestroyed$)).subscribe();

    this.listService.getWithoutPageReset();
  }

  private SetStatusToGeborgen(): void
  {
    let selectedGhostItem = this._selectedElementByContextMenu;

    let updatedGhostNet = this._ghostNetRequestDtoFactory.Create(selectedGhostItem, GhostNetStatusEnum.Geborgen);
    console.log(updatedGhostNet)
    this._ghostNetsService.update(updatedGhostNet).pipe(takeUntil(this._componentDestroyed$)).subscribe();

    this.listService.getWithoutPageReset();
  }

  private SetStatusToVerschollen(): void
  {
    let selectedGhostItem = this._selectedElementByContextMenu;

    let updatedGhostNet = this._ghostNetRequestDtoFactory.Create(selectedGhostItem, GhostNetStatusEnum.Verschollen);
    console.log(updatedGhostNet)
    this._ghostNetsService.update(updatedGhostNet).pipe(takeUntil(this._componentDestroyed$)).subscribe();

    this.listService.getWithoutPageReset();
  }

  private InitiateContextMenu(): void
  {
    this.availableContextActions.push(
      ContextMenuActionFactory.CreateAvailableContextActions(this._localizationService.instant('::SetStatusToGemeldet'), (() => this.SetStatusToGemeldet()), "pen"),
      ContextMenuActionFactory.CreateAvailableContextActions(this._localizationService.instant('::SetStatusToBergungBevorstehend'), (() => this.SetStatusToBergungBevorstehend()), "pen"),
      ContextMenuActionFactory.CreateAvailableContextActions(this._localizationService.instant('::SetStatusToGeborgen'), (() => this.SetStatusToGeborgen()), "pen"),
      ContextMenuActionFactory.CreateAvailableContextActions(this._localizationService.instant('::SetStatusToVerschollen'), (() => this.SetStatusToVerschollen()), "pen"));
  }
}
