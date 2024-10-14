import { Component, OnInit } from '@angular/core';
import { CategoryType, Exam, ExamsClient,GetExamResponse,Question } from '../../api/api-reference';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-take-exam',
  templateUrl: './take-exam.component.html',
  styleUrls: ['./take-exam.component.scss']
})
export class TakeExamComponent implements OnInit {
  exam: GetExamResponse | null = null; 
  filteredQuestions: any[] = [];
  constructor(
    private readonly client: ExamsClient,
    private router: Router,
    private route: ActivatedRoute 
  ) {}

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      const examIdParam = params.get('id');
      if (examIdParam !== null) {
        const examId = +examIdParam; 
        this.getExam(examId);
        const categories = this.getUniqueCategories();
        this.filteredQuestions = this.getQuestionsByCategory(categories[0]); 
      } else {
        console.error('Exam ID parameter is null.');
      }
    });
  }
  

  getExam(id: number): void {
    this.client.get(id).subscribe(
      exam => {
        this.exam = exam; 
        console.log(this.exam);
      },
      (error: any) => {
        console.error('Error fetching exam:', error);
      }
    );
  }

  getUniqueCategories(): string[] {
    if (!this.exam || !this.exam.questions) {
      return [];
    }
    const categoriesSet = new Set<string>();
    this.exam.questions.forEach((question: Question) => {
      if (question.category !== undefined) { 
        const categoryString = CategoryType[question.category]; 
        categoriesSet.add(categoryString);
      }
    });
    return Array.from(categoriesSet);
  }
  getQuestionsByCategory(category: string): Question[] {
    if (!this.exam || !this.exam.questions) {
      return [];
    }
    const categoryType: CategoryType = CategoryType[category.toUpperCase() as keyof typeof CategoryType];
    return this.exam.questions.filter((question: Question) => question.category === categoryType);
  }

  setFilteredQuestions(category: string): void{
    this.filteredQuestions = this.getQuestionsByCategory(category);
  }

}

