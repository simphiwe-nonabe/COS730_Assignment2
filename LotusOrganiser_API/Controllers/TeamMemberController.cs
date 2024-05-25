using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using LotusOrganiser.Entities;
using LotusOrganiser_API.Models.TeamMember;
using LotusOrganiser_Repository.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace LotusOrganiser_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamMemberController : Controller
    {
        private readonly ITeamMemberRepository _teamMemberRepository;

        private readonly IMapper _mapper;

        public TeamMemberController(ITeamMemberRepository teamMemberRepository, IMapper mapper)
        {
            _teamMemberRepository = teamMemberRepository;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("AddTeamMember")]
        [SwaggerOperation(OperationId = nameof(AddTeamMember))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<TeamMember>))]
        public async Task<IActionResult> AddTeamMember([FromBody] TeamMemberCreationModel teamMember)
        {
            TeamMember mappedTeamMember = _mapper.Map<TeamMember>(teamMember);
            TeamMember  mappedResult = await _teamMemberRepository.AddTeamMemberAsync(mappedTeamMember);
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("GetAllTeamMembers")]
        [SwaggerOperation(OperationId = nameof(GetAllTeamMembers))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<TeamMemberViewModel>))]
        public async Task<IActionResult> GetAllTeamMembers()
        {
            IEnumerable<TeamMember> teamMembers = await _teamMemberRepository.GetAllTeamMembersAsync();
            List<TeamMemberViewModel> mappedResult = teamMembers.Select(_mapper.Map<TeamMemberViewModel>).ToList();
            return Ok(mappedResult);
        }

        [HttpPut]
        [Route("UpdateTeamMember")]
        [SwaggerOperation(OperationId = nameof(UpdateTeamMember))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<TeamMember>))]
        public async Task<IActionResult> UpdateTeamMember([FromRoute] long id, [FromBody] TeamMemberCreationModel teamMember)
        {
            TeamMember teamMemberToUpdate = _mapper.Map<TeamMember>(teamMember);
            TeamMember result = await _teamMemberRepository.UpdateTeamMemberAsync(id, teamMemberToUpdate);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpDelete]
        [Route("DeleteTeamMember")]
        [SwaggerOperation(OperationId = nameof(DeleteTeamMember))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<TeamMember>))]
        public async Task<IActionResult> DeleteTeamMember(long id)
        {
            TeamMember? deletedTeamMember = await _teamMemberRepository.DeleteTeamMemberAsync(id);
            return deletedTeamMember == null ? NotFound() : Ok(deletedTeamMember);
        }

        [HttpGet]
        [Route("GetTeamMembersByTeamId/{id:long}")]
        [SwaggerOperation(OperationId = nameof(GetTeamMembersByTeamId))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<TeamMemberViewModel>))]
        public async Task<IActionResult> GetTeamMembersByTeamId([FromRoute] long id)
        {
            IEnumerable<TeamMember> teamMembers = await _teamMemberRepository.GetTeamMembersByTeamIdAsync(id);
            if (teamMembers == null)
            {
                return NotFound();
            }
            TeamMemberViewModel mappedResult = _mapper.Map<TeamMemberViewModel>(teamMembers);
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("FindTeamsMemberBelongsToByName/{name}")]
        [SwaggerOperation(OperationId = nameof(FindTeamsMemberBelongsToByName))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<TeamMemberViewModel>))]
        public async Task<IActionResult> FindTeamsMemberBelongsToByName([FromRoute] string name)
        {
            IEnumerable<TeamMember> teamMembers = await _teamMemberRepository.FindTeamsMemberBelongsToByNameAsync(name);

            if (teamMembers == null || teamMembers.Count() == 0)
            {
                return NotFound();
            }
            List<TeamMemberViewModel> mappedResult = teamMembers.Select(_mapper.Map<TeamMemberViewModel>).ToList();
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("FindTeamMembersByTeamName/{name}")]
        [SwaggerOperation(OperationId = nameof(FindTeamMembersByTeamName))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<TeamMemberViewModel>))]
        public async Task<IActionResult> FindTeamMembersByTeamName([FromRoute] string name)
        {
            IEnumerable<TeamMember> teamMembers = await _teamMemberRepository.FindTeamMembersByTeamNameAsync(name);

            if (teamMembers == null || teamMembers.Count() == 0)
            {
                return NotFound();
            }
            List<TeamMemberViewModel> mappedResult = teamMembers.Select(_mapper.Map<TeamMemberViewModel>).ToList();
            return Ok(mappedResult);
        }

    }
}
