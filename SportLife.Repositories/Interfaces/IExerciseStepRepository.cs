using SportLife.Context.Models;

namespace SportLife.Repositories.Interfaces
{
    public interface IExerciseStepRepository : IDisposable
    {
        Task<IReadOnlyCollection<ExerciseStep>> GetByExerciseId(Guid exerciseId, CancellationToken cancellationToken);
        ExerciseStep? GetExerciseStep(Guid id);
        void Create(ExerciseStep item);
        void Update(ExerciseStep item);
        void Delete(Guid id);
        void Save();
    }
}
