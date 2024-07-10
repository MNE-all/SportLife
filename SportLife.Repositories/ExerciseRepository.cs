using Microsoft.EntityFrameworkCore;
using SportLife.Context;
using SportLife.Context.Enums;
using SportLife.Context.Models;
using SportLife.Repositories.Interfaces;
using System.Collections.Immutable;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Collections.ObjectModel;

namespace SportLife.Repositories
{
    public class ExerciseRepository : IExerciseRepository
    {
        private SportLifeContext db;

        public ExerciseRepository(SportLifeContext db)
        {
            this.db = db;
        }
        public void Create(Exercise item)
        {
            db.Exercise.Add(item);
        }

        public void Delete(Guid id)
        {
            var exercise = db.Exercise.FirstOrDefault(x => x.Id == id);
            if (exercise != null)
            {
                db.Exercise.Remove(exercise);
            }
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Task<IReadOnlyCollection<Exercise>> GetAllAsync(CancellationToken cancellationToken) => db.Exercise.Include(x => x.ExerciseSteps).ToListAsync(cancellationToken).ContinueWith(x => new ReadOnlyCollection<Exercise>(x.Result) as IReadOnlyCollection<Exercise>,
                    cancellationToken);

        public Exercise? GetExercise(Guid id) => db.Exercise.FirstOrDefault(x => x.Id == id);

        public Task<IReadOnlyCollection<Exercise>> GetExercisesByMuscleTypeAsync(MuscleType type, CancellationToken cancellationToken) => db.Exercise.Where(x => x.MuscleTypes.Contains(type))
            .ToListAsync(cancellationToken).ContinueWith(x => new ReadOnlyCollection<Exercise>(x.Result) as IReadOnlyCollection<Exercise>,
                    cancellationToken);

        public Task<IReadOnlyCollection<Exercise>> GetExercisesByTypeAsync(ExerciseType type, CancellationToken cancellationToken) => db.Exercise.Where(x => x.ExerciseTypes.Contains(type))
            .ToListAsync(cancellationToken).ContinueWith(x => new ReadOnlyCollection<Exercise>(x.Result) as IReadOnlyCollection<Exercise>,
                    cancellationToken);

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Exercise item)
        {
            db.Exercise.Update(item);
        }
    }
}
