using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using LotusOrganiser.Entities;
using LotusOrganiser_Repository.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using LotusOrganiser_API.Models.Team;

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
        [SwaggerOperation(OperationId = nameof(GetAllTeams))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<TeamViewModel>))]
        public async Task<IActionResult> GetAllTeams()
        {
            IEnumerable<Team> result = await _teamRepository.GetAllTeamsAsync();
            List<TeamViewModel> mappedResult = result.Select(_mapper.Map<TeamViewModel>).ToList();
            return Ok(mappedResult);
        }

        [HttpPost]
        [Route("CreateTeam")]
        [SwaggerOperation(OperationId = nameof(CreateTeam))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<Team>))]
        public async Task<IActionResult> CreateTeam([FromBody] TeamCreationModel team)
        {
            Team mappedTeam = _mapper.Map<Team>(team);
            Team result  = await _teamRepository.CreateTeamAsync(mappedTeam);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetTeamById/{id:long}")]
        [SwaggerOperation(OperationId = nameof(GetTeamById))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<TeamViewModel>))]
        public async Task<IActionResult> GetTeamById([FromRoute] long id)
        {
            Team? team = await _teamRepository.GetTeamByIdAsync(id);
            if (team == null)
            {
                return NotFound();
            }
            TeamViewModel mappedResult = _mapper.Map<TeamViewModel>(team);
            return Ok(mappedResult);
        }

        [HttpPut]
        [Route("UpdateTeam/{id:long}")]
        [SwaggerOperation(OperationId = nameof(UpdateTeam))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<Team>))]
        public async Task<IActionResult> UpdateTeam([FromRoute] long id, [FromBody] TeamCreationModel teamToUpdate)
        {
            Team mappedTeam = _mapper.Map<Team>(teamToUpdate);

            Team? updatedTeam = await _teamRepository.UpdateTeamAsync(id, mappedTeam);
            return updatedTeam == null ? NotFound() : Ok(updatedTeam);
        }

        [HttpDelete]
        [Route("DeleteTeam")]
        [SwaggerOperation(OperationId = nameof(DeleteTeam))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<Team>))]
        public async Task<IActionResult> DeleteTeam(long id)
        {
            Team? deletedTeam = await _teamRepository.DeleteTeamAsync(id);
            return deletedTeam == null ? NotFound() : Ok(deletedTeam);
        }
    }

}