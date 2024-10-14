using Forms.FormsContext;
using Forms.Models.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Forms.Models.Exams;

public static class GetExam
{
    public class Request : IRequest<Response?>
    {
        public long Id { get; set; }
    }

    public class Response
    {
        public long Id { get; set; }
        public IEnumerable<QuestionResponse> Questions { get; set; } = Enumerable.Empty<QuestionResponse>();
    }

    public class QuestionResponse
    {
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public CategoryType Category { get; set; }
        public AnswerType Type { get; set; }
        public int Score { get; set; }
        public IEnumerable<AnswerResponse> Answers { get; set; } = Enumerable.Empty<AnswerResponse>();


    }
    public class AnswerResponse
    {
        public long Id { get; set; }
        public string AnswerName { get; set; } = "";
        public bool IsSelected { get; set; }
    }

    public class RequestHandler : IRequestHandler<Request, Response?>
    {
        private readonly DbSet<Exam> _dbSet;
        private readonly DbSet<Answer> _answers;

        public RequestHandler(FormsDatabaseContext context)
        {
            _dbSet = context.Set<Exam>();
            _answers = context.Set<Answer>();
        }

        public async Task<Response?> Handle(Request request, CancellationToken cancellationToken)
        {
            var exam = await _dbSet.Include(x => x.Questions).SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            return exam == null ? null : new Response
            {
                Id = exam.Id,
                Questions = exam.Questions.Select(x => new QuestionResponse
                {
                    Title = x.Title,
                    Category = x.Category,
                    Type = x.Type,
                    Score = x.Score,
                    Answers = _answers.Where(a => x.Id == a.QuestionId).Select(a => new AnswerResponse
                    {
                        Id = a.Id,
                        IsSelected = a.IsSelected,
                        AnswerName = a.AnswerName
                    }).ToList()
                })
            };
        }
    }
}

