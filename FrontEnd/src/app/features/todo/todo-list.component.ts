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

  todos:ToDo[] = [];

  constructor(private router : Router, 
    private todoService: TodoService) { }

  ngOnInit(): void {
    this.getTodos();
  }
  getTodos():void{
    this.todoService
        .getTodos()
        .subscribe((todoResult)=>(this.todos = todoResult))
}

}
