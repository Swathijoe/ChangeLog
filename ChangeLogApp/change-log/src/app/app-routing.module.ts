import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LogDetailComponent } from './log-detail/log-detail.component';
import { LogListComponent } from './log-list/log-list.component';
import { LoginComponent } from './login/login.component';

export const routes: Routes = [    
  { component: LoginComponent, path: '', pathMatch: 'full' },
  { component: LogListComponent, path: 'log-list' } ,
  { component: LogDetailComponent, path: 'log/:id' } 
]; 

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
