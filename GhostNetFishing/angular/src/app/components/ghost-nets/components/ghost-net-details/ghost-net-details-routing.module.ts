import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { GhostNetDetailsComponent } from './ghost-net-details.component';

const routes: Routes = [{ path: '', component: GhostNetDetailsComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class GhostNetDetailsRoutingModule { }
