using SportLife.Context.Enums;
using SportLife.Context.Models;

namespace SportLife.Repositories.Interfaces
{
    public interface IExerciseRepository : IDisposable
    {
        Task<IReadOnlyCollection<Exercise>> GetAllAsync(CancellationToken cancellationToken);
        Task<IReadOnlyCollection<Exercise>> GetExercisesByTypeAsync(ExerciseType type,  CancellationToken cancellationToken);
        Task<IReadOnlyCollection<Exercise>> GetExercisesByMuscleTypeAsync(MuscleType type, CancellationToken cancellationToken);
        Exercise? GetExercise(Guid id);
        void Create(Exercise item);
        void Update(Exercise item);
        void Delete(Guid id);
        void Save();
    }
}
