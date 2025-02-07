using Microsoft.AspNetCore.Mvc;

namespace SaplingStore.Interfaces;

public interface IController<in TUpdateDto> where TUpdateDto : IUpdateDto
{
    // public Task<IActionResult> GetAllGenericEntity();
    public Task<IActionResult> GetByEntityId(int id);
    public Task<IActionResult> Update(int id, TUpdateDto updateSaplingCategoryReadDto);
    public Task<IActionResult> Delete([FromRoute] int id);
}