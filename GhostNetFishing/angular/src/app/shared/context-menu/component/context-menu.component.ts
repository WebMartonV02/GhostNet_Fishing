import { Component, Input } from '@angular/core';
import { CoordinatePosition } from '../../models/coordinate-position.model';
import { ContextMenuActionModel } from '../models/context-menu-action.model';

@Component({
  selector: 'abp-context-menu',
  templateUrl: './context-menu.component.html',
  styleUrls: ['./context-menu.component.scss']
})
export class ContextMenuComponent
{
  @Input() coordinatePosition: CoordinatePosition;
  @Input() isShow: boolean;
  @Input() availableContextActions: Array<ContextMenuActionModel>;

  constructor() { }

  public OnContextActionClicked(element: ContextMenuActionModel)
  {
    element?.callbackMethod();
  }
}
