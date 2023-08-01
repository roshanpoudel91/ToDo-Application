import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToDo } from 'src/app/core/models/todo';
import { CategoryService } from 'src/app/core/services/category.service';
import { PriorityService } from 'src/app/core/services/priority.service';
import { TodoService } from 'src/app/core/services/todo.service';
import { UserService } from 'src/app/core/services/user.service';

@Component({
  selector: 'app-add-to-do',
  templateUrl: './add-to-do.component.html',
  styleUrls: ['./add-to-do.component.css']
})
export class AddToDoComponent implements OnInit {

  model: ToDo = {} as ToDo;
  form!: NgForm;
  todo_button: string = "SAVE";
  todo_add: string = "Add ToDo";
  submitted:boolean = false;
  categories:any;
  priorities:any;
  users:any;
  statuss = ["created","started","completed"];

  constructor(private todoService: TodoService,
    private categoryService: CategoryService,
    private priorityService: PriorityService,
    private userService: UserService,
    

    private route: ActivatedRoute,
   
    private router : Router
  ) { }

  ngOnInit(): void {

    // get list of category 
    this.categoryService
    .getCategories()
    .subscribe((categoryResult) => {
      this.categories = categoryResult;
    });

    // get list of priority

    this.priorityService
    .getPriorities()
    .subscribe((priorityResult) => {
      this.priorities = priorityResult;
    });


    // get list of users
    this.userService
    .getByRole("User")
    .subscribe((userResult) => {
      this.users = userResult;
    });


    
    const id = parseInt(this.route.snapshot.paramMap.get('id')!, 10);
    //if id is present in url, form will act as update form otherwise it will act as add form.
    if (id) {
      this.todo_button = "UPDATE";
      this.todo_add = "Edit ToDo";
      this.getTodo(id);
    }
  }

  back(): void {
    // this.location.back();
    this.router.navigate(['site/todo'])
  }

  addTodo(form: NgForm) {
    // form:NgForm parameter has to be deleted after api implemented

    if (form.invalid) { this.submitted=true;return; }

    if (this.model) {
      console.log(this.model);
      //if id is present, it will update form otherwise it will add form.
      if (this.model.todoId) {
        this.todoService.updateTodo(this.model)
          .subscribe(() => this.back());

      } else {

        this.todoService.addTodo(this.model)
          .subscribe(() => this.back());

      }

    }
  }

  getTodo(id: number): void {
    // get the category id from the URL
    // const id = parseInt(this.route.snapshot.paramMap.get('id')!, 10);
    console.log("todo_id", id);
    this.todoService
      .getTodo(id)
     
      .subscribe((todoResult:any) => {
        this.model= todoResult[0];
        console.log(this.model);
      });


  }


}
