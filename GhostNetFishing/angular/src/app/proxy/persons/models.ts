import type { PersonTypeResultDto } from '../person-types/models';

export interface PersonRequestDto {
  id: number;
  name?: string;
  telefonNummer?: string;
  personTypeId: number;
}

export interface PersonResultDto {
  name?: string;
  telefonNummer?: string;
  personType: PersonTypeResultDto;
}
