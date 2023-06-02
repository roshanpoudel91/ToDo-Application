import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Category } from 'src/app/core/models/category';
import { CategoryService } from 'src/app/core/services/category.service';
import { faTable, faEdit, faTrash } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-list-category',
  templateUrl: './list-categories.component.html',
  styleUrls: ['./list-categories.component.css']
})
export class ListCategoriesComponent implements OnInit {

  // dataSource = [
  //   { id: 1, name: 'John Doe', date: "2022-05-25", description:"Hello" },
  //   { id: 2, name: 'John Doe', date: "2022-05-25", description:"Hello" },
  //   { id: 3, name: 'John Doe', date: "2022-05-25", description:"Hello" },
  //   { id: 4, name: 'John Doe', date: "2022-05-25", description:"Hello" },
  //   { id: 5, name: 'John Doe', date: "2022-05-25", description:"Hello" },
  //   { id: 6, name: 'John Doe', date: "2022-05-25", description:"Hello" },
  //   { id: 7, name: 'John Doe', date: "2022-05-25", description:"Hello" },
  //   { id: 8, name: 'John Doe', date: "2022-05-25", description:"Hello" },
    
  // ];
  faTable = faTable;
  faEdit = faEdit;
  faTrash = faTrash;
  categories: Category[] = [];

  pageSize = 10; 
  currentPage = 1; 

  constructor(private router : Router, 
              private categoryService: CategoryService) { }

  ngOnInit(): void {
    this.getCategories();
  }

  getCategories():void{
        this.categoryService
            .getCategories()
            .subscribe((categoryResult)=>(this.categories = categoryResult))
  }

  addCategory(){
    this.router.navigate(['site/add-category']);
  }

}
