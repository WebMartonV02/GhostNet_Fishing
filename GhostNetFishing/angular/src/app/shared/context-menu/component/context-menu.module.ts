import { NgModule } from '@angular/core';
import { SharedModule } from '../../shared.module';
import { ContextMenuComponent } from './context-menu.component';

@NgModule({
  declarations: [
    ContextMenuComponent
  ],
  imports: [
    SharedModule
  ],
  exports: [
    ContextMenuComponent
  ]
})

export class ContextMenuModule { }
