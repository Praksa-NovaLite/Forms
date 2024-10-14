import { Component, OnInit } from '@angular/core';
import { Exam, ExamsClient } from '../../api/api-reference';

@Component({
  selector: 'app-exam-list',
  templateUrl: './exam-list.component.html',
  styleUrls: ['./exam-list.component.scss']
})

export class ExamListComponent implements OnInit {
  exams: Exam[] = [];

  constructor(
    private readonly client: ExamsClient) { }

  ngOnInit(): void {
    this.client.getExams().subscribe({
      next: (exams: Exam[]) => this.exams = exams,
      error: (err: any) => console.error('Error fetching exams:', err)
    });
  }
}