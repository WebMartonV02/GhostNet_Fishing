import { NgModule } from '@angular/core';
import { ContextMenuModule } from '../../shared/context-menu/component/context-menu.module';
import { SharedModule } from '../../shared/shared.module';
import { GhostNetPersonsRoutingModule } from './ghost-net-persons-routing.module';
import { GhostNetPersonsComponent } from './ghost-net-persons.component';

@NgModule({
  declarations: [GhostNetPersonsComponent],
  imports:
    [
      SharedModule,
      GhostNetPersonsRoutingModule,
      ContextMenuModule
    ],
})
export class GhostNetPersonsModule {}
