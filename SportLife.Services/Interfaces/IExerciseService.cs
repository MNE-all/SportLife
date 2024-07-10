using SportLife.Context.Models;
using SportLife.Services.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace SportLife.Services.Interfaces
{
    public interface IExerciseService
    {
        public Task Add(ExerciseRequest exercise);
        public Task<IReadOnlyCollection<Exercise>> GetAll(CancellationToken cancellationToken);
    }
}
