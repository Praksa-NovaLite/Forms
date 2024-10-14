using Forms.FormsContext;
using Forms.Models.Exams;
using MassTransit;
using Questions.Dtos;

namespace Forms.Consumers
{
    public class ExamConsumer : IConsumer<ExamDto>
    {
        private readonly FormsDatabaseContext _context;


        public ExamConsumer(FormsDatabaseContext context)
        {
            _context = context;
        }

        public async Task Consume(ConsumeContext<ExamDto> context)
        {

            var exam = new Exam
            {
                CandidateId = context.Message.CandidateId,
                Questions = [],
                MaxScore = context.Message.MaxScore
            };

            var QuestionIds = context.Message.Questions.Select(x => x.Id).ToList();
            var existingQuestions = _context.Questions.Where(x => QuestionIds.Contains(x.Id)).ToList();
            var existingQuestionIds = existingQuestions.Select(x => x.Id);
            exam.Questions.AddRange(existingQuestions);
            exam.Questions.AddRange(context.Message.Questions.Where(x => !existingQuestionIds.Contains(x.Id)));


            _context.Add(exam);

            await _context.SaveChangesAsync();
        }
    }
}
