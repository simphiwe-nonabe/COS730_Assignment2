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

    public class TeamController : Controller
    {
        private readonly ITeamRepository _teamRepository;

        private readonly IMapper _mapper;

        public TeamController(ITeamRepository teamRepository, IMapper mapper)
        {
            _teamRepository = teamRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetAllTeams")]
        [SwaggerOperation(OperationId = nameof(GetAllTeamsAsync))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<TeamViewModel>))]
        public async Task<IActionResult> GetAllTeamsAsync()
        {
            IEnumerable<Team> result = await _teamRepository.GetAllTeamsAsync();

            List<TeamViewModel> mappedResult = result.Select(_mapper.Map<TeamViewModel>).ToList();
            return Ok(mappedResult);
        }

        [HttpPost]
        [Route("CreateTeam")]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<Team>))]
        public async Task<IActionResult> CreateTeamAsync([FromBody] Team team)
        {
            team = await _teamRepository.CreateTeamAsync(team);
            return Ok(team);
        }
    }

}