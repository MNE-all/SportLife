using SportLife.Context.Models;
using SportLife.Services.Models;

namespace SportLife.Services.Interfaces
{
    public interface IExerciseStepService
    {
        public Task Add(ExerciseStepRequest exercise);
        public Task Remove(Guid guid);
        public Task Update(Guid guid, string description);

        public Task<IReadOnlyCollection<ExerciseStep>> GetByExerciseId(Guid exerciseId, CancellationToken cancellationToken);

    }
}
