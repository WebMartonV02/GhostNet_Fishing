import { RoutesService, eLayoutType, PermissionGuard } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const APP_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routesService: RoutesService) {
  return () => {
    routesService.add([
      {
        path: '/',
        name: '::Menu:Home',
        iconClass: 'fas fa-home',
        order: 1,
        layout: eLayoutType.application,
      },
      {
        path: '/ghost-nets',
        name: '::Menu:GhostNets',
        iconClass: 'fas fa-network-wired',
        order: 2,
        layout: eLayoutType.application,
        requiredPolicy: 'GhostNetFishing.GeisterNetz'
      },
      {
        path: '/ghost-net-persons',
        name: '::Menu:GhostNetsAndPersons',
        iconClass: 'fa-solid fa-user',
        order: 4,
        layout: eLayoutType.application,
        requiredPolicy: 'GhostNetFishing.GeisterNetz'
      },
    ]);
  };
}
