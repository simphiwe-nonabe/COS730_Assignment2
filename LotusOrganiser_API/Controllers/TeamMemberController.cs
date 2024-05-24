using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using LotusOrganiser.Entities;
using LotusOrganiser_API.Models.Person;
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
        [SwaggerResponse(StatusCodes.Status204NoContent)]
        //public async Task<IActionResult> AddTeamMember([FromBody] TeamMemberCreationModel teamMember)
        public async Task<IActionResult> AddTeamMember([FromBody] TeamMember teamMember)
        {

            //TeamMember mappedTeamMember = _mapper.Map<TeamMember>(teamMember);
            //await _teamMemberRepository.AddTeamMemberAsync(mappedTeamMember);
            TeamMember  mappedResult = await _teamMemberRepository.AddTeamMemberAsync(teamMember);

            return Ok(mappedResult);
            //return NoContent();
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

        [HttpGet]
        [Route("GetTeamMemberById/{id:long}")]
        [SwaggerOperation(OperationId = nameof(GetTeamMemberById))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<TeamMemberViewModel>))]
        public async Task<IActionResult> GetTeamMemberById([FromRoute] long id)
        {
            TeamMember? teamMember = await _teamMemberRepository.GetTeamMemberByIdAsync(id);
            if (teamMember == null)
            {
                return NotFound();
            }
            TeamMemberViewModel mappedResult = _mapper.Map<TeamMemberViewModel>(teamMember);
            return Ok(mappedResult);
        }

        [HttpPut]
        [Route("UpdateTeamMember")]
        [SwaggerOperation(OperationId = nameof(UpdateTeamMember))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateTeamMember([FromBody] TeamMemberUpdateModel teamMember)
        {
            TeamMember teamMemberToUpdate = _mapper.Map<TeamMember>(teamMember);
            await _teamMemberRepository.UpdateTeamMemberAsync(teamMemberToUpdate);
            return NoContent();
        }

        [HttpDelete]
        [Route("DeleteTeamMember")]
        [SwaggerOperation(OperationId = nameof(DeleteTeamMember))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteTeamMember(long id)
        {
            TeamMember? deletedTeamMember = await _teamMemberRepository.DeleteTeamMemberAsync(id);
            return deletedTeamMember == null ? NotFound() : Ok(deletedTeamMember);
        }

        [HttpGet]
        [Route("FindTeamMembersByName/{name}")]
        [SwaggerOperation(OperationId = nameof(FindTeamMembersByName))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<TeamMemberViewModel>))]
        public async Task<IActionResult> FindTeamMembersByName([FromRoute] string name)
        {
            IEnumerable<TeamMember> teamMembers = await _teamMemberRepository.FindTeamMembersByNameAsync(name);

            if (teamMembers == null || teamMembers.Count() == 0)
            {
                return NotFound();
            }
            List<TeamMemberViewModel> mappedResult = teamMembers.Select(_mapper.Map<TeamMemberViewModel>).ToList();
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("FindTeamMembersByTeamMemberType/{name}")]
        [SwaggerOperation(OperationId = nameof(FindTeamMembersByTeamMemberTypeAsync))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<TeamMemberViewModel>))]
        public async Task<IActionResult> FindTeamMembersByTeamMemberTypeAsync([FromRoute] string name)
        {
            IEnumerable<TeamMember> teamMembers = await _teamMemberRepository.FindTeamMembersByTeamMemberTypeAsync(name);

            if (teamMembers == null || teamMembers.Count() == 0)
            {
                return NotFound();
            }
            List<TeamMemberViewModel> mappedResult = teamMembers.Select(_mapper.Map<TeamMemberViewModel>).ToList();
            return Ok(mappedResult);
        }

    }
}
