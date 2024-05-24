using AutoMapper;
using LotusOrganiser.Entities;
using LotusOrganiser_API.Models.Person;

namespace LotusOrganiser_API.Mapping
{
    internal sealed class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<Person, PersonViewModel>();

            CreateMap<PersonCreationModel, Person>();
        }
    }
}