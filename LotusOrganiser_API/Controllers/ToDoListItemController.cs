using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using LotusOrganiser.Entities;
using LotusOrganiser_Repository.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using LotusOrganiser_API.Models.ToDoListItem;
using LotusOrganiser_Repository.Repositories;

namespace LotusOrganiser_API.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ToDoListItemController : Controller
    {
        private readonly IToDoListItemRepository _itemRepository;

        private readonly IMapper _mapper;

        public ToDoListItemController(IToDoListItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("CreateToDoListItem")]
        [SwaggerOperation(OperationId = nameof(CreateToDoListItem))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<ToDoListItem>))]
        public async Task<IActionResult> CreateToDoListItem([FromBody] ToDoListItemCreationModel item)
        {
            ToDoListItem mappedItem = _mapper.Map<ToDoListItem>(item);
            ToDoListItem result = await _itemRepository.CreateToDoListItemAsync(mappedItem);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetAllToDoListItems")]
        [SwaggerOperation(OperationId = nameof(GetAllToDoListItemsAsync))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<ToDoListItemViewModel>))]
        public async Task<IActionResult> GetAllToDoListItemsAsync()
        {
            IEnumerable<ToDoListItem> result = await _itemRepository.GetAllToDoListItemsAsync();
            List<ToDoListItemViewModel> mappedResult = result.Select(_mapper.Map<ToDoListItemViewModel>).ToList();
            return Ok(mappedResult);
        }

        [HttpPut]
        [Route("UpdateToDoListItem/{id:long}")]
        [SwaggerOperation(OperationId = nameof(UpdateToDoListItem))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<ToDoListItem>))]
        public async Task<IActionResult> UpdateToDoListItem([FromRoute] long id, [FromBody] ToDoListItemCreationModel itemToUpdate)
        {
            ToDoListItem mappedItem = _mapper.Map<ToDoListItem>(itemToUpdate);

            ToDoListItem? updatedItem = await _itemRepository.UpdateToDoListItemAsync(id, mappedItem);
            return updatedItem == null ? NotFound() : Ok(updatedItem);
        }

        [HttpDelete]
        [Route("DeleteToDoListItem")]
        [SwaggerOperation(OperationId = nameof(DeleteToDoListItem))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<ToDoListItem>))]
        public async Task<IActionResult> DeleteToDoListItem(long id)
        {
            ToDoListItem? deletedItem = await _itemRepository.DeleteToDoListItemAsync(id);
            return deletedItem == null ? NotFound() : Ok(deletedItem);
        }


        [HttpGet]
        [Route("GetToDoListItemById/{id:long}")]
        [SwaggerOperation(OperationId = nameof(GetToDoListItemById))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<ToDoListItemViewModel>))]
        public async Task<IActionResult> GetToDoListItemById([FromRoute] long id)
        {
            ToDoListItem? item = await _itemRepository.GetToDoListItemByIdAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            ToDoListItemViewModel mappedResult = _mapper.Map<ToDoListItemViewModel>(item);
            return Ok(mappedResult);
        }
    }

}