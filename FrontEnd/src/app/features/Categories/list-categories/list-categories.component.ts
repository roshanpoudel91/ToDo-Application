import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-list-category',
  templateUrl: './list-categories.component.html',
  styleUrls: ['./list-categories.component.css']
})
export class ListCategoriesComponent implements OnInit {

  dataSource = [
    { id: 1, name: 'John Doe', date: "2022-05-25", description:"Hello" },
    { id: 2, name: 'John Doe', date: "2022-05-25", description:"Hello" },
    { id: 3, name: 'John Doe', date: "2022-05-25", description:"Hello" },
    { id: 4, name: 'John Doe', date: "2022-05-25", description:"Hello" },
    { id: 5, name: 'John Doe', date: "2022-05-25", description:"Hello" },
    { id: 6, name: 'John Doe', date: "2022-05-25", description:"Hello" },
    { id: 7, name: 'John Doe', date: "2022-05-25", description:"Hello" },
    { id: 8, name: 'John Doe', date: "2022-05-25", description:"Hello" },
    
  ];

  pageSize = 5; 
  currentPage = 1; 

  constructor(private router : Router) { }

  ngOnInit(): void {
  }

  addCategory(){
    this.router.navigate(['site/add-category']);
  }

}
