import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Category } from 'src/app/core/models/category';
import { CategoryService } from 'src/app/core/services/category.service';

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  // styleUrls: ['./categories.component.css']
})
export class CategoriesComponent implements OnInit {
  categories: Category[] = [];

   // declare our ng for form for adding person type
   @ViewChild('form')
   form!: NgForm;
   model: Category = {} as Category;

  constructor( private categoryService : CategoryService) { }

  ngOnInit(): void {
    this.getCategory();
  }

  getCategory(): void {
    console.log("Inside category component");
    this.categoryService
      .getCategories()
      .subscribe((categoryResult) => (this.categories = categoryResult));
  }


}
