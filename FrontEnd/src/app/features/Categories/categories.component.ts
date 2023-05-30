import { Component, OnInit } from '@angular/core';
import { jsonArray } from './data';

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.css']
})
export class CategoriesComponent implements OnInit {

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

  constructor() { }

  ngOnInit(): void {
  }

}
