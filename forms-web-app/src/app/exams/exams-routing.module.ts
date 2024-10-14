import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ExamListComponent } from './exam-list/exam-list.component';
import { QuestionDetailsComponent } from './question-details/question-details.component';
import { TakeExamComponent } from './take-exam/take-exam.component';


const routes: Routes = [
  {
    path: '',
    component: ExamListComponent
  },
  { path: 'exam/:id', 
    component: TakeExamComponent 
  }, 
  {
    path: 'take/:id',
    component: ExamListComponent
  },
  {
    path: 'question/:id',
    component: QuestionDetailsComponent
  }
]
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ExamsRoutingModule { }
