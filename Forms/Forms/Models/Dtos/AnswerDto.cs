namespace Questions.Dtos;

public class AnswerDto
{
    public long Id { get; set; }
    public required string AnswerName { get; set; }
    public required bool IsSelected { get; set; }
}
