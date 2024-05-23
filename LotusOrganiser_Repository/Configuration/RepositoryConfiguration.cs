using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using LotusOrganiser_Repository.Interfaces;
using LotusOrganiser_Repository.Repositories;
using LotusOrganiser_Repository.Services;

namespace LotusOrganiser_Repository.Configuration
{
    public static class RepositoryConfiguration
    {
        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.TryAddTransient<IUserRepository, UserRepository>();
            services.TryAddTransient<ITrainingRepository, TrainingRepository>();
            services.TryAddTransient<ILevelRepository, LevelRepository>();
            services.TryAddTransient<ITrainingStatusRepository, TrainingStatusRepository>();
            services.TryAddTransient<ICertificationRepository, CertificationRepository>();
            services.TryAddTransient<IUserCertificationRepository, UserCertificationRepository>();
            services.TryAddTransient<IMotivationFormRepository, MotivationFormRepository>();
            services.TryAddTransient<IMotivationFormService, MotivationFormService>();
            services.TryAddTransient<ITrainingService, TrainingService>();
            services.TryAddTransient<ITrainingHRRepository, TrainingHRRepository>();
            services.TryAddTransient<ITrainingHRService, TrainingHRService>();
            services.TryAddTransient<ICertificationTypeRepository, CertificationTypeRepository>();
            services.TryAddTransient<ITrainingProviderRepository, TrainingProviderRepository>();
            services.TryAddTransient<ITrainingReasonRepository, TrainingReasonRepository>();
        }
    }
}