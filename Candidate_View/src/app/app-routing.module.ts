import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CViewComponent } from './candidate/c-view/c-view.component';
import { AppComponent } from './app.component';

const routes: Routes = [
  {
    path:'',
    component: AppComponent
  },
  {
    path:'view',
    component: CViewComponent
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
