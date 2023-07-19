import { Component, OnInit } from '@angular/core';
import { TodoService } from 'src/app/core/services/todo.service';
import { Router } from '@angular/router';
import { ToDo } from 'src/app/core/models/todo';

@Component({
  selector: 'app-todo-list',
  templateUrl: './todo-list.component.html',
  styleUrls: ['./todo-list.component.css']
})
export class TodoListComponent implements OnInit {

 
  todos: ToDo[] = [];
  originalTodos: ToDo[] = []; // To store the original list before filtering
  searchQuery: string = '';

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
        this.originalTodos = todoResult; // Store original data when fetching
      });
  }

  search(): void {
    if (this.searchQuery.trim() !== '') {
      this.todos = this.originalTodos.filter(item =>
        item.name.toLowerCase().includes(this.searchQuery.trim().toLowerCase())
      );
    }
  }

  clear(): void {
    this.searchQuery = ''; // Clear the search query
    this.todos = this.originalTodos; // Restore the original data
  }
}