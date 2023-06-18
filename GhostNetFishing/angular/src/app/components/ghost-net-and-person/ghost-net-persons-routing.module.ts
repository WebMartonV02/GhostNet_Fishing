import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GhostNetPersonsComponent } from './ghost-net-persons.component';

const routes: Routes = [{ path: '', component: GhostNetPersonsComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class GhostNetPersonsRoutingModule {}
