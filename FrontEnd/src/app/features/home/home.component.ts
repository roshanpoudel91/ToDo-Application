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

<<<<<<< HEAD
  GotoPriority(){
    "List the Priorities"
    console.log("Inside Priority");
    this.router.navigate(['site/priority']);

=======
  GotoPriorities(){
    console.log("Inside Goto Priorities");
    this.router.navigate(['site/priority']);
  }

  addPriority(){
    this.router.navigate(['site/add-priority']);
>>>>>>> 488f9320bcf4ca92ff946fa0e26d33be8adc4c64
  }

}
