import { Component, Input } from '@angular/core';
import { QuestionDto } from '../../../api/api-reference';

@Component({
  selector: 'app-checkbox-question',
  templateUrl: './checkbox-question.component.html',
  styleUrl: './checkbox-question.component.scss'
})
export class CheckboxQuestionComponent {
@Input() question!: QuestionDto;
}
