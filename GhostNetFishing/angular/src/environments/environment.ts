import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'GhostNetFishing',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44330/',
    redirectUri: baseUrl,
    clientId: 'GhostNetFishing_App',
    responseType: 'code',
    scope: 'offline_access GhostNetFishing',
    requireHttps: true,
  },
  apis: {
    default: {
      url: 'https://localhost:44330',
      rootNamespace: 'GhostNetFishing',
    },
  },
} as Environment;
