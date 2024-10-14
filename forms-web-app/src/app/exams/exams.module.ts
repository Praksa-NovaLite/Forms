import { NgModule } from "@angular/core";
import { MatFormField, MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { ReactiveFormsModule } from "@angular/forms";
import { CommonModule } from "@angular/common";
import { MatListModule } from '@angular/material/list';
import { MatTableModule } from '@angular/material/table';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { ExamListComponent } from "./exam-list/exam-list.component";
import { ExamsRoutingModule } from "./exams-routing.module";
import {MatRadioModule} from '@angular/material/radio';
import { QuestionDetailsComponent } from "./question-details/question-details.component";
import { MatCardModule } from '@angular/material/card';
import { RadioButtonQuestionComponent } from './question-details/radio-button-question/radio-button-question.component';
import { CheckboxQuestionComponent } from './question-details/checkbox-question/checkbox-question.component';
import { FlexLayoutModule } from "@angular/flex-layout";
import { TakeExamComponent } from "./take-exam/take-exam.component";


@NgModule({
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatFormField,
    MatInputModule,
    MatSelectModule,
    MatButtonModule,
    MatListModule,
    MatTableModule,
    MatToolbarModule,
    MatCheckboxModule,
    ExamsRoutingModule,
    MatRadioModule,
    MatButtonModule,
    FlexLayoutModule,
    MatCardModule
  ],
  declarations: [
    ExamListComponent,
    TakeExamComponent,
    QuestionDetailsComponent,
    RadioButtonQuestionComponent,
    CheckboxQuestionComponent
  ],
  exports: [
    ExamListComponent
  ]
})
export class ExamsModule { }