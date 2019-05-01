import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DashboardComponent, FindComponent } from './components';

const routes: Routes = [
  { path: 'dashboard', component: DashboardComponent, children: [
    { path: 'find', component: FindComponent }
  ]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }