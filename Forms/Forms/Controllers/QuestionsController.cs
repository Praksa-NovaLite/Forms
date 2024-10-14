using AutoMapper;
using Forms.FormsContext;
using Forms.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Questions.Dtos;

namespace Forms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : Controller
    {
        private readonly FormsDatabaseContext _context;
        private readonly IMapper _mapper;

        public QuestionsController(FormsDatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<List<QuestionDto>> GetQuestionsForExam(long examId)
        {
            var exam = _context.Exams
                 .Include(e => e.Questions)
                 .FirstOrDefault(e => e.Id == examId);

            if (exam == null)
            {
                return NotFound();
            }
            var questionDtos = _mapper.Map<List<QuestionDto>>(exam.Questions);

            return questionDtos;
        }

        [HttpGet("{questionId}")]
        public ActionResult<QuestionDto> GetQuestionDetails(long questionId)
        {
            var question = _context.Questions
                            .Include(q => q.Answers)
                            .FirstOrDefault(q => q.Id == questionId);
            if (question == null)
            {
                return NotFound();
            }

            var questionDto = _mapper.Map<QuestionDto>(question);
            questionDto.Answers = _mapper.Map<List<AnswerDto>>(question.Answers);

            return questionDto;
        }
    }
}
