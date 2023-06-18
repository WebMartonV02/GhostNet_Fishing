import type { GhostNetResultDto } from '../ghost-nets/models';
import type { PersonResultDto } from '../persons/models';

export interface GhostNetAndPersonRequestDto {
  id: number;
  ghostNetId: number;
  personId: number;
}

export interface GhostNetAndPersonResultDto {
  ghostNet: GhostNetResultDto;
  person: PersonResultDto;
}
