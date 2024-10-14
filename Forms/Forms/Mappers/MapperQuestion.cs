using AutoMapper;
using Forms.Models;
using Questions.Dtos;
namespace Forms.Mappers;

public class MapperQuestion : Profile
{
    public MapperQuestion()
    {
        CreateMap<Question, QuestionDto>();
        CreateMap<QuestionDto, Question>();
    }
}
