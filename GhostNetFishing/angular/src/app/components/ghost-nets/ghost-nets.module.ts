import { NgModule } from '@angular/core';
import { SharedModule } from '../../shared/shared.module';
import { GhostNetsRoutingModule } from './ghost-net-routing.module';
import { GhostNetsComponent } from './ghost-nets.component';

@NgModule({
  declarations: [GhostNetsComponent],
  imports:
    [
      SharedModule,
      GhostNetsRoutingModule
    ],
})
export class GhostNetsModule {}
