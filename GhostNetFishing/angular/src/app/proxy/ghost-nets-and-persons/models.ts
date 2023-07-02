import type { GhostNetResultDto } from '../ghost-nets/models';
import type { UserResultDto } from '../user/models';

export interface GhostNetAndPersonRequestDto {
  id: number;
  ghostNetId: number;
  userId?: string;
}

export interface GhostNetAndPersonResultDto {
  ghostNet: GhostNetResultDto;
  user: UserResultDto;
}
