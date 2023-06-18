import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    loadChildren: () => import('././components/home/home.module').then(m => m.HomeModule),
  },
  {
    path: 'account',
    loadChildren: () => import('@abp/ng.account').then(m => m.AccountModule.forLazy()),
  },
  {
    path: 'identity',
    loadChildren: () => import('@abp/ng.identity').then(m => m.IdentityModule.forLazy()),
  },
  {
    path: 'tenant-management',
    loadChildren: () =>
      import('@abp/ng.tenant-management').then(m => m.TenantManagementModule.forLazy()),
  },
  {
    path: 'setting-management',
    loadChildren: () =>
      import('@abp/ng.setting-management').then(m => m.SettingManagementModule.forLazy()),
  },
  {
    path: 'ghost-nets',
    pathMatch: 'full',
    loadChildren: () => import('././components/ghost-nets/ghost-nets.module').then(m => m.GhostNetsModule),
  },
  {
    path: 'persons',
    pathMatch: 'full',
    loadChildren: () => import('././components/persons/persons.module').then(m => m.PersonsModule),
  },
  {
    path: 'ghost-net-persons',
    pathMatch: 'full',
    loadChildren: () => import('././components/ghost-net-and-person/ghost-net-persons.module').then(m => m.GhostNetPersonsModule),
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {})],
  exports: [RouterModule],
})
export class AppRoutingModule {}
