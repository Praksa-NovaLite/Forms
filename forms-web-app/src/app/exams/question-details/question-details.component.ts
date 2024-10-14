import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FormArray, FormControl, FormGroup, UntypedFormGroup } from '@angular/forms';
import { AnswerType, QuestionDto, QuestionsClient } from '../../api/api-reference';

@Component({
  selector: 'app-question-details',
  templateUrl: './question-details.component.html',
  styleUrl: './question-details.component.scss'
})
export class QuestionDetailsComponent {
  AnswerType = AnswerType;
  question!: QuestionDto;
  id!: number;
  form = new FormGroup({
    answers: new FormArray<UntypedFormGroup>([])
  })

  constructor(private questionService: QuestionsClient,
    private route: ActivatedRoute) {
    this.route.params.subscribe(params => {
      const questionId = params['id'];
      if (questionId) {
        this.questionService.getQuestionDetails(questionId).subscribe(
          data => {
            this.question = data;
          },
          (error) => {
            console.error('Error fetching question details:', error);
          }
        );
      }
    });
  }
}
