import { Component, OnInit } from '@angular/core';
import { TodoService } from 'src/app/core/services/todo.service';
import { Router } from '@angular/router';
import { ToDo } from 'src/app/core/models/todo';
import { faTable, faEdit, faTrash } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-todo-list',
  templateUrl: './todo-list.component.html',
  styleUrls: ['./todo-list.component.css']
})
export class TodoListComponent implements OnInit {

  faTable = faTable;
  faEdit = faEdit;
  faTrash = faTrash;
  selectedItem!:number;
  todos: ToDo[] = [];
  originalTodos: ToDo[] = []; 
  searchQuery: string = '';
  selectedPriority: string = '';
  selectedCategory: string = '';
  selectedSortOption: string = 'name';
  priorities: string[] = [];
  categories: string[] = [];
  constructor(private router : Router, 
    private todoService: TodoService) { }

  ngOnInit(): void {
    this.getTodos();
  }
  getTodos(): void {
    this.todoService
      .getTodos()
      .subscribe((todoResult) => {
        this.todos = todoResult;
        this.originalTodos = todoResult;
        this.extractPrioritiesAndCategories(todoResult); 
      });
  }
  extractPrioritiesAndCategories(todos: ToDo[]): void {
    this.priorities = Array.from(new Set(todos.map(todo => todo.priorities.name)));
    this.categories = Array.from(new Set(todos.map(todo => todo.categories.name)));
  }

  search(): void {
    if (this.searchQuery.trim() !== '') {
      this.todos = this.originalTodos.filter(item =>
        item.name.toLowerCase().includes(this.searchQuery.trim().toLowerCase())
      );
    }
  }

  clear(): void {
    this.searchQuery = ''; 
    this.todos = this.originalTodos; 
  }
  applyFilter(): void {
    let filteredTodos = this.originalTodos;
  
    if (this.selectedPriority) {
      filteredTodos = filteredTodos.filter(todo => todo.priorities.name === this.selectedPriority);
    }
  
    if (this.selectedCategory) {
      filteredTodos = filteredTodos.filter(todo => todo.categories.name === this.selectedCategory);
    }
  
    if (this.selectedSortOption === 'id') {
      filteredTodos = filteredTodos.sort((a, b) => a.todoId - b.todoId);
    } else if (this.selectedSortOption === '-id') {
      filteredTodos = filteredTodos.sort((a, b) => b.todoId - a.todoId);
    }
  
    this.todos = filteredTodos;
  }

  addTodo():void{
    this.router.navigate(['site/add-todo']);
  }

  goToEdit(id:number){
    console.log('todo_id',id);
    this.router.navigate([`/site/edit-todo/${id}`])
  }

  deleteTodo(): void {
    console.log(this.selectedItem)
    this.todoService.deleteTodo(this.selectedItem).subscribe(() => {
      console.log('Todo deleted!');
      // Refresh the categories list after deletion
      this.getTodos();
    });
  }


}