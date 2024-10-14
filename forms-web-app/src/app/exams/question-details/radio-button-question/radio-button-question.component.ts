import { Component, Input } from '@angular/core';
import { Question } from '../../../api/api-reference';

@Component({
  selector: 'app-radio-button-question',
  templateUrl: './radio-button-question.component.html',
  styleUrl: './radio-button-question.component.scss'
})
export class RadioButtonQuestionComponent {
  @Input() question!: Question;
}
