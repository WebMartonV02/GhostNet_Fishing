import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { GhostNetsComponent } from './ghost-nets.component';

const routes: Routes = [{ path: '', component: GhostNetsComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class GhostNetsRoutingModule {}
