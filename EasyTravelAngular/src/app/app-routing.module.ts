import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DashboardComponent, FindComponent, AuthComponent, LoginComponent, RegisterComponent } from './components';
import { AuthGuardService } from './guards';

const routes: Routes = [
  {
    path: '', component: AuthComponent, children: [
      { path: "", redirectTo: "/login", pathMatch: "full" },
      {
        path: 'login',
        component: LoginComponent
      },
      {
        path: 'register',
        component: RegisterComponent
      }
    ]
  },
  {
    path: 'dashboard', component: DashboardComponent, canActivate: [AuthGuardService], children: [
      { path: "", redirectTo: "/dashboard/find", pathMatch: "full" },
      {
        path: 'find',
        component: FindComponent
      }
    ]
  },
  { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
