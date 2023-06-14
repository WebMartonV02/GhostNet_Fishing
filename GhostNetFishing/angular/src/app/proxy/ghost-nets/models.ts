import type { GhostNetStatusResultDto } from '../ghost-net-statuses/models';

export interface GhostNetResultDto {
  id: number;
  standort?: string;
  estimatedSize?: string;
  ghostNetStatusId: number;
  ghostNetStatus: GhostNetStatusResultDto;
}
