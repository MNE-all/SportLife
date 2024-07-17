using Microsoft.AspNetCore.Mvc;
using SportLife.Context.Models;
using SportLife.Services.Interfaces;
using SportLife.Services.Models;

namespace SportLife.API.Controllers
{
    public class ExerciseController : Controller
    {
        private IExerciseService exerciseService;
        private IExerciseStepService stepService;
        private readonly ILogger<UserController> _logger;

        public ExerciseController(ILogger<UserController> logger, IExerciseService exerciseService, IExerciseStepService exerciseStepService)
        {
            _logger = logger;
            this.exerciseService = exerciseService;
            stepService = exerciseStepService;
        }

        /// <summary>
        /// Просмотр упражнений
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAll")]
        public IReadOnlyCollection<Exercise> GetUsers()
        {
            return exerciseService.GetAll(new CancellationToken()).Result;
        }

        /// <summary>
        /// Добавление упражнения
        /// </summary>
        /// <param name="exerciseRequest"></param>
        /// <returns></returns>
        [HttpPost("Add")]
        public Task Add(ExerciseRequest exerciseRequest)
        {
            return exerciseService.Add(exerciseRequest);
        }

        /// <summary>
        /// Добавление шага упражнения
        /// </summary>
        /// <param name="exerciseStepRequest"></param>
        /// <returns></returns>
        [HttpPost("AddStep")]
        public Task AddStep(ExerciseStepRequest exerciseStepRequest)
        {
            return stepService.Add(exerciseStepRequest);
        }

        /// <summary>
        /// Просмотр шагов для выполнения упражнения
        /// </summary>
        /// <param name="id">Идентификатор упражнения</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("GetStepsByExerciseId")]
        public IReadOnlyCollection<ExerciseStep> GetStepsByExerciseId(Guid id, CancellationToken cancellationToken)
        {
            return stepService.GetByExerciseId(id, cancellationToken).Result;
        }
    }
}
