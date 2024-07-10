using AutoMapper;
using SportLife.Context.Models;
using SportLife.Repositories.Interfaces;
using SportLife.Services.Interfaces;
using SportLife.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportLife.Services
{
    public class ExerciseStepService : IExerciseStepService
    {
        private IExerciseStepRepository exerciseStepRepository;
        private IMapper mapper;
        public ExerciseStepService (IExerciseStepRepository stepRepository, IMapper mapper)
        {
            this.mapper = mapper;
            exerciseStepRepository = stepRepository;
        }
        public Task Add(ExerciseStepRequest exercise)
        {
            exerciseStepRepository.Create(mapper.Map<ExerciseStep>(exercise));
            return Task.CompletedTask;
        }

        public Task<IReadOnlyCollection<ExerciseStep>> GetByExerciseId(Guid exerciseId, CancellationToken cancellationToken)
        {
            return exerciseStepRepository.GetByExerciseId(exerciseId, cancellationToken);
        }

        public Task Remove(Guid guid)
        {
            exerciseStepRepository.Delete(guid);
            return Task.CompletedTask;
        }

        public Task Update(Guid guid, string description)
        {
            var exerciseStep = exerciseStepRepository.GetExerciseStep(guid);
            if (exerciseStep != null)
            {
                exerciseStep.Description = description;
                exerciseStepRepository.Update(exerciseStep);
            }
            return Task.CompletedTask;
        }
    }
}
