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
import { UserListComponent } from './features/users/list/user-list.component';
import { AddUserComponent } from './features/users/add/add-user.component';
import { TodoListComponent } from './features/todo/list-todo/todo-list.component';
import { AddToDoComponent } from './features/todo/add-todo/add-to-do.component';


const routes: Routes = [
  { path: '', redirectTo: 'site/home', pathMatch: 'full' },
  { path: 'register', component: RegisterComponent },
  { path: 'login', component: LoginComponent },
  
  {
    path: 'site',
    canActivate: [AuthGuard],
    children: [
      { path: 'home', component: HomeComponent },
      { path: 'category',component: ListCategoriesComponent},
      { path: 'priority',component: ListPrioritiesComponent},
      { path: 'user',component: UserListComponent},
      { path: 'todo',component: TodoListComponent},
      {path:'add-category', component:AddCategoryComponent},
      {path:'add-priority', component:AddPriorityComponent},
      {path:'add-user', component:AddUserComponent},
      {path:'add-todo', component:AddToDoComponent},
      {
        path: 'edit-category/:id',
        component: AddCategoryComponent,   
      },
      {
        path: 'edit-priority/:id',
        component: AddPriorityComponent,   
      },
      {
        path: 'edit-user/:id',
        component: AddUserComponent,   
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
  exports: [RouterModule]
})
export class AppRoutingModule {}
