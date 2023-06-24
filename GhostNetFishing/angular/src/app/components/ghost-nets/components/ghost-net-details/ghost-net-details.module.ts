import { NgModule } from '@angular/core';
import { ContextMenuModule } from '../../../../shared/context-menu/component/context-menu.module';
import { SharedModule } from '../../../../shared/shared.module';
import { GhostNetDetailsRoutingModule } from './ghost-net-details-routing.module';
import { GhostNetDetailsComponent } from './ghost-net-details.component';
import { NgSelectModule } from "@ng-select/ng-select";

@NgModule({
  declarations: [GhostNetDetailsComponent],
  imports:
    [
      SharedModule,
      GhostNetDetailsRoutingModule,
      ContextMenuModule,
      NgSelectModule,
    ],
})
export class GhostNetDetailsModule { }
