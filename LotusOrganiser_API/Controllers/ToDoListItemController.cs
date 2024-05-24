using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using LotusOrganiser.Entities;
using LotusOrganiser_API.Models;
using LotusOrganiser_Repository.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

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

        [HttpGet]
        [Route("GetAllToDoListItems")]
        [SwaggerOperation(OperationId = nameof(GetAllToDoListItemsAsync))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        //[SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<ToDoListItemViewModel>))]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<ToDoListItem>))]
        public async Task<IActionResult> GetAllToDoListItemsAsync()
        {
            IEnumerable<ToDoListItem> result = await _itemRepository.GetAllToDoListItemsAsync();

            //List<ToDoListItemViewModel> mappedResult = result.Select(_mapper.Map<ToDoListItemViewModel>).ToList();
            //return Ok(mappedResult);

            return Ok(result);
        }

        [HttpPost]
        [Route("CreateToDoListItem")]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<ToDoListItem>))]
        public async Task<IActionResult> CreateToDoListItemAsync([FromBody] ToDoListItem item)
        {
            item = await _itemRepository.CreateToDoListItemAsync(item);
            return Ok(item);
        }
    }

}