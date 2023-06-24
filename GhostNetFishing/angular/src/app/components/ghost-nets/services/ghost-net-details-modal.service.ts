import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { NgbModal, NgbModalOptions } from '@ng-bootstrap/ng-bootstrap';
import { GhostNetDetailsComponent } from "../components/ghost-net-details/ghost-net-details.component";

@Injectable()
export class GhostNetDetailsModelService
{
  constructor(private _ngbModalService: NgbModal) { }

  public OpenModalWithCloseOption(): Observable<undefined>
  {
    let ngbModalOptions: NgbModalOptions =
    {
      size: 'xl'
    };

    const modalRef = this._ngbModalService.open(GhostNetDetailsComponent, ngbModalOptions);

    return modalRef.closed;
  }
}
