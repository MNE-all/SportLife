using Microsoft.EntityFrameworkCore;
using SportLife.Context;
using SportLife.Context.Models;
using SportLife.Repositories.Interfaces;
using System.Collections.ObjectModel;

namespace SportLife.Repositories
{
    public class ExerciseStepRepository : IExerciseStepRepository
    {
        SportLifeContext db;
        public ExerciseStepRepository(SportLifeContext sportLifeContext)
        {
            db = sportLifeContext;
        }
        public void Create(ExerciseStep item)
        {
            var find = db.ExerciseSteps.OrderBy(x => x.Step).LastOrDefault();
            if (find != null )
            {
                item.Step = find.Step + 1;
            }
            db.ExerciseSteps.Add(item);
        }

        public void Delete(Guid id)
        {
            var ex = db.ExerciseSteps.FirstOrDefault(x => x.Id == id);
            if (ex != null)
            {
                db.ExerciseSteps.Remove(ex);
            }
        }

        public Task<IReadOnlyCollection<ExerciseStep>> GetByExerciseId(Guid exerciseId, CancellationToken cancellationToken)
        {
            return db.ExerciseSteps.Where(x => x.ExerciseId == exerciseId).OrderBy(x => x.Step).ToListAsync(cancellationToken)
                .ContinueWith(x => new ReadOnlyCollection<ExerciseStep>(x.Result) as IReadOnlyCollection<ExerciseStep>,
                    cancellationToken);
        }

        public ExerciseStep? GetExerciseStep(Guid id)
        {
            return db.ExerciseSteps.FirstOrDefault(x => x.Id == id);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(ExerciseStep item)
        {
            db.ExerciseSteps.Update(item);
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
    }
}
