using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using LotusOrganiser.Entities;
using LotusOrganiser_API.Models.Person;
using LotusOrganiser_Repository.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using System;

namespace LotusOrganiser_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : Controller
    {
        private readonly IPersonRepository _personRepository;

        private readonly IMapper _mapper;
        public PersonController(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("AddPerson")]
        [SwaggerOperation(OperationId = nameof(AddPerson))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<Person>))]
        public async Task<IActionResult> AddPerson([FromBody] PersonCreationModel person)
        {
            Person mappedPerson = _mapper.Map<Person>(person);
            Person result = await _personRepository.AddPersonAsync(mappedPerson);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetAllPersons")]
        [SwaggerOperation(OperationId = nameof(GetAllPersons))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<PersonViewModel>))]
        public async Task<IActionResult> GetAllPersons()
        {
            IEnumerable<Person> persons = await _personRepository.GetAllPersonsAsync();
            List<PersonViewModel> mappedResult = persons.Select(_mapper.Map<PersonViewModel>).ToList();
            return Ok(mappedResult);
        }

        [HttpPut]
        [Route("UpdatePerson/{id:long}")]
        [SwaggerOperation(OperationId = nameof(UpdatePerson))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<Person>))]
        public async Task<IActionResult> UpdatePerson([FromRoute] long id, [FromBody] PersonCreationModel personToUpdate)
        {
            Person mappedPerson = _mapper.Map<Person>(personToUpdate);

            Person? updatedPerson = await _personRepository.UpdatePersonAsync(id, mappedPerson);
            return updatedPerson == null ? NotFound() : Ok(updatedPerson);
        }

        [HttpDelete]
        [Route("DeletePerson")]
        [SwaggerOperation(OperationId = nameof(DeletePerson))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<Person>))]
        public async Task<IActionResult> DeletePerson(long id)
        {
            Person? deletedPerson = await _personRepository.DeletePersonAsync(id);
            return deletedPerson == null ? NotFound() : Ok(deletedPerson);
        }

        [HttpGet]
        [Route("GetPersonById/{id:long}")]
        [SwaggerOperation(OperationId = nameof(GetPersonById))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<PersonViewModel>))]
        public async Task<IActionResult> GetPersonById([FromRoute] long id)
        {
            Person? person = await _personRepository.GetPersonByIdAsync(id);
            if (person == null)
            {
                return NotFound();
            }
            PersonViewModel mappedResult = _mapper.Map<PersonViewModel>(person);
            return Ok(mappedResult);
        }

        [HttpGet]
        [Route("FindPersonsByName/{name}")]
        [SwaggerOperation(OperationId = nameof(FindPersonsByName))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<PersonViewModel>))]
        public async Task<IActionResult> FindPersonsByName([FromRoute] string name)
        {
            IEnumerable<Person> persons = await _personRepository.FindPersonsByNameAsync(name);
            if (persons == null || persons.Count() == 0)
            {
                return NotFound();
            }

            List<PersonViewModel> mappedResult = persons.Select(_mapper.Map<PersonViewModel>).ToList();
            return Ok(mappedResult);
        }
    }
}
