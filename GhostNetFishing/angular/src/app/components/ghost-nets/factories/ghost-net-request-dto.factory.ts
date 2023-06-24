import { GhostNetRequestDto, GhostNetResultDto } from "../../../proxy/ghost-nets";

export class GhostNetRequestDtoFactory
{
  public Create(
    selectedGhostItem: GhostNetResultDto,
    selectedStatusId: number): GhostNetRequestDto
  {
    let result: GhostNetRequestDto = {} as GhostNetRequestDto;

    result.id = selectedGhostItem.id;
    result.estimatedSize = selectedGhostItem.estimatedSize;
    result.location = selectedGhostItem.location;
    result.ghostNetStatusId = selectedStatusId;

    return result;
  }
}
