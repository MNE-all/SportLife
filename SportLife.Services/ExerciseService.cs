using AutoMapper;
using SportLife.Context.Models;
using SportLife.Repositories.Interfaces;
using SportLife.Services.Interfaces;
using SportLife.Services.Models;
using System.Collections.ObjectModel;

namespace SportLife.Services
{
    public class ExerciseService : IExerciseService
    {
        IExerciseRepository repository;
        IMapper mapper;
        public ExerciseService(IExerciseRepository exerciseRepository, IMapper mapper)
        {
            repository = exerciseRepository;
            this.mapper = mapper;
        }
        Task IExerciseService.Add(ExerciseRequest exercise)
        {
            repository.Create(mapper.Map<Exercise>(exercise));
            repository.Save();
            return Task.CompletedTask;
        }

        Task<IReadOnlyCollection<Exercise>> IExerciseService.GetAll(CancellationToken cancellationToken)
        {
            return repository.GetAllAsync(cancellationToken);            
        }
    }
}
