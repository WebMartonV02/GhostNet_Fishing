import { NgModule } from '@angular/core';
import { ContextMenuModule } from '../../shared/context-menu/component/context-menu.module';
import { SharedModule } from '../../shared/shared.module';
import { GhostNetsRoutingModule } from './ghost-net-routing.module';
import { GhostNetsComponent } from './ghost-nets.component';

@NgModule({
  declarations: [GhostNetsComponent],
  imports:
    [
      SharedModule,
      GhostNetsRoutingModule,
      ContextMenuModule
    ],
})
export class GhostNetsModule {}
