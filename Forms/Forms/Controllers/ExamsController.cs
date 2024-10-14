using Forms.FormsContext;
using Forms.Models.Exams;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Forms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamsController : ControllerBase
    {
        private readonly FormsDatabaseContext _context;
        private readonly IMediator _mediatr;

        public ExamsController(FormsDatabaseContext context, IMediator mediatr)
        {
            _context = context;
            _mediatr = mediatr;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetExam.Response>> GetAsync(long id)
        {
            var result = await _mediatr.Send(new GetExam.Request { Id = id });

            return result == null ? NotFound() : Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Exam>>> GetExams()
        {
            return await _context.Exams.Include(exam => exam.Questions).ToListAsync();
        }

    }
}
