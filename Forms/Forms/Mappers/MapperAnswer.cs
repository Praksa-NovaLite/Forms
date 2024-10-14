using AutoMapper;
using Forms.Models;
using Questions.Dtos;
namespace Forms.Mappers;

public class MapperAnswer : Profile
{
    public MapperAnswer()
    {
        CreateMap<Answer, AnswerDto>();
        CreateMap<AnswerDto, Answer>();
    }
}
