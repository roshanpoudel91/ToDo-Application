import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './core/guards/auth.guard';
import { HomeComponent } from './features/home/home.component';
import { LoginComponent } from './features/users/login/login.component';
import { RegisterComponent } from './features/users/register/register.component';
import { PageNotFoundComponent } from './ui/page-not-found/page-not-found.component';
import { ListCategoriesComponent } from './features/categories/list-categories/list-categories.component';
import { AddCategoryComponent } from './features/categories/add-category/add-category.component';
import { AddPriorityComponent } from './features/priorities/add-priority/add-priority.component';
import { ListPrioritiesComponent } from './features/priorities/list-priorities/list-priorities.component';


const routes: Routes = [
  { path: '', redirectTo: 'site/home', pathMatch: 'full' },
  { path: 'register', component: RegisterComponent },
  { path: 'login', component: LoginComponent },
  
  {
    path: 'site',
   // canActivate: [AuthGuard],
    children: [
      { path: 'home', component: HomeComponent },
      { path: 'category',component: ListCategoriesComponent},
      { path: 'priority',component: ListPrioritiesComponent},
      {path:'add-category', component:AddCategoryComponent},
      {path:'add-priority', component:AddPriorityComponent},
      {
        path: 'edit-category/:id',
        component: AddCategoryComponent,   
      },
      {
        path: 'edit-priority/:id',
        component: AddPriorityComponent,   
      },
      {
        path: 'maintenance',
        children: [
        ],
      },
    ],
  },
  //Wild Card Route for 404 request
  { path: '**', pathMatch: 'full', component: PageNotFoundComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
