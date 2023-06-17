import { NgModule } from '@angular/core';
import { ContextMenuModule } from '../../shared/context-menu/component/context-menu.module';
import { SharedModule } from '../../shared/shared.module';
import { PersonsRoutingModule } from './persons-routing.module';
import { PersonsComponent } from './persons.component';

@NgModule({
  declarations: [PersonsComponent],
  imports:
    [
      SharedModule,
      PersonsRoutingModule,
      ContextMenuModule
    ],
})
export class PersonsModule {}
