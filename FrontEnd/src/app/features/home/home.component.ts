import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(private router : Router) { }

  ngOnInit(): void {
  }

  GotoCategories(){
    console.log("Inside Goto Categories");
    this.router.navigate(['site/category']);

  }

  GotoPriorities(){
    console.log("Inside Goto Priorities");
    this.router.navigate(['site/priority']);
  }

  addPriority(){
    this.router.navigate(['site/add-priority']);
  }

  GotoToDos(){
    console.log("Inside Goto Todos");
    this.router.navigate(['site/todo']);
  }

}
