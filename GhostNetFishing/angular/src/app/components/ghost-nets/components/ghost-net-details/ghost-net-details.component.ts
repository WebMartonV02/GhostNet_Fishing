import { Component, OnDestroy, OnInit } from "@angular/core";
import { Subject, takeUntil } from "rxjs";
import { NgbActiveModal } from "@ng-bootstrap/ng-bootstrap";
import { GhostNetRequestDto, GhostNetsService } from "../../../../proxy/ghost-nets";
import { GhostNetStatusResultDto, GhostNetStatusService } from "../../../../proxy/ghost-net-statuses";

@Component({
  selector: 'app-ghost-net-details',
  templateUrl: 'ghost-net-details.component.html',
  styleUrls: ['ghost-net-details.component.scss']
})
export class GhostNetDetailsComponent implements OnInit, OnDestroy
{
  public requestModel: GhostNetRequestDto = {} as GhostNetRequestDto;
  public ghostNetStatuses: Array<GhostNetStatusResultDto> = new Array<GhostNetStatusResultDto>;
  public selectedGhostNet: GhostNetStatusResultDto = {} as GhostNetStatusResultDto;

  private _componentDestroyed$: Subject<void> = new Subject();

  public constructor(
    private readonly _ghostNetService: GhostNetsService,
    private readonly _ghostNetStatusService: GhostNetStatusService,
    private _ngbActiveModal: NgbActiveModal) { }

  ngOnInit(): void
  {
    this.GetAllGhostNetStatuses();
  }

  ngOnDestroy(): void
  {
    this._componentDestroyed$.next();
    this._componentDestroyed$.complete();
  }

  public Close(): void
  {
    this._ngbActiveModal.dismiss();
  }

  public Save(): void
  {
    const request = this.requestModel.id
      ? this._ghostNetService.update(this.requestModel)
      : this._ghostNetService.create(this.requestModel);

    request
      .pipe(takeUntil(this._componentDestroyed$))
      .subscribe(() =>
      {
        this._ngbActiveModal.close();
      });
  }

  private GetAllGhostNetStatuses(): void
  {
    this._ghostNetStatusService.getAllWithNested()
      .pipe(takeUntil(this._componentDestroyed$))
      .subscribe((data: Array<GhostNetStatusResultDto>) =>
      {
        this.ghostNetStatuses = data;
      })
  }
} 
