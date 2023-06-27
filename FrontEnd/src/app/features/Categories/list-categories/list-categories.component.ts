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

  faTable = faTable;
  faEdit = faEdit;
  faTrash = faTrash;
  categories: Category[] = [];

  pageSize = 10; 
  currentPage = 1; 
  deleteCategoryId:number = 0;

  constructor(private router : Router, 
              private categoryService: CategoryService) { }

  ngOnInit(): void {
    this.getCategories();
  }

  goToEdit(id:number){
    console.log('category_id',id);
    this.router.navigate([`/site/edit-category/${id}`])
  }

  goToDelete(id:number){
    this.deleteCategoryId = id;
  }

  getCategories():void{
        this.categoryService
            .getCategories()
            .subscribe((categoryResult)=>(this.categories = categoryResult))
  }

  addCategory(){
    this.router.navigate(['site/add-category']);
  }
  deleteCategory(): void {

    this.categoryService.deleteCategory(this.deleteCategoryId).subscribe(() => {
      console.log('Category deleted!');
      // Refresh the categories list after deletion
      this.getCategories();
    });
  }

}
