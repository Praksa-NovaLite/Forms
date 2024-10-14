using AutoMapper;
using Forms.Models.Exams;
using Questions.Dtos;
namespace Forms.Mappers;

public class MapperExam : Profile
{
    public MapperExam()
    {
        CreateMap<Exam, ExamDto>();
        CreateMap<ExamDto, Exam>();
    }
}

