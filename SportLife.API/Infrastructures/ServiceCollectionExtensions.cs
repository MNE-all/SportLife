using AutoMapper;
using SportLife.Repositories;
using SportLife.Repositories.Interfaces;
using SportLife.Services;
using SportLife.Services.Interfaces;

namespace SportLife.API.Infrastructures
{
    static internal class ServiceCollectionExtensions
    {
        public static void AddDependencies(this IServiceCollection service)
        {
            service.AddScoped<IExerciseRepository, ExerciseRepository>();
            service.AddTransient<IExerciseService, ExerciseService>();
            service.AddScoped<IExerciseStepRepository, ExerciseStepRepository>();
            service.AddTransient<IExerciseStepService, ExerciseStepService>();

            //service.AddAutoMapper();
            service.AddSingleton<IMapper>(provider =>
            {
                var profiles = provider.GetServices<Profile>();
                var mapperConfig = new MapperConfiguration(mc =>
                {
                    foreach (var profile in profiles)
                    {
                        mc.AddProfile(profile);
                    }
                });
                var mapper = mapperConfig.CreateMapper();
                return mapper;
            });

            service.AddSingleton<Profile, ServiceProfile>();
        }
    }
}
