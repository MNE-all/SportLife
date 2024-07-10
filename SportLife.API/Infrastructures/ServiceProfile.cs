using AutoMapper;
using SportLife.Context.Models;
using SportLife.Services.Models;

namespace SportLife.API.Infrastructures
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            CreateMap<Exercise, ExerciseRequest>().ReverseMap();
            CreateMap<ExerciseStep, ExerciseStepRequest>().ReverseMap();
        }
    }
}
