using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using LotusOrganiser_Repository.Interfaces;
using LotusOrganiser_Repository.Repositories;

namespace LotusOrganiser_Repository.Configuration
{
    public static class RepositoryConfiguration
    {
        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.TryAddTransient<ITeamRepository, TeamRepository>();
            services.TryAddTransient<ITeamMemberRepository, TeamMemberRepository>();
            services.TryAddTransient<IPersonRepository, PersonRepository>();
            services.TryAddTransient<IToDoListItemRepository, ToDoListItemRepository>();
        }
    }
}