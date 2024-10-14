import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

export const routes: Routes = [
  {
      path: 'exams',
      loadChildren: () => import('./exams/exams.module').then(m => m.ExamsModule)
  },
  {
      path:'',
      redirectTo: 'exams',
      pathMatch: 'full'
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }