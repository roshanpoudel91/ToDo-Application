import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Category } from 'src/app/core/models/category';
import { CategoryService } from 'src/app/core/services/category.service';
import { faTable, faEdit, faTrash } from '@fortawesome/free-solid-svg-icons';
import { Subject } from 'rxjs';

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
  defaultCategories: Category[] = [];
  private resetCategories$: Subject<void> = new Subject<void>();
  searchTerm: string = '';
  selectedItem!:number;
  pageSize = 10; 
  currentPage = 1; 

  constructor(private router : Router, 
              private categoryService: CategoryService) { }

  ngOnInit(): void {
    this.getCategories();
    this.resetCategories$
    .subscribe(() => {
      // Reset the categories to their default state
      this.categories = this.defaultCategories;
    });
        
  }
  

  goToEdit(id:number){
    console.log('category_id',id);
    this.router.navigate([`/site/edit-category/${id}`])
  }
  searchCategories(): void {
    // Implement the logic to filter the categories based on the search term
    const filteredCategories = this.categories.filter(category =>
      category.name.toLowerCase().includes(this.searchTerm.toLowerCase())
    );

    // Assign the filtered categories to the categories array
    this.categories = filteredCategories;
  }
  clearSearch(): void {
    this.searchTerm = ''; // Clear the search term
    this.resetCategories$.next(); // Trigger the reset of categories to default
  }
  getCategories():void{
        this.categoryService
            .getCategories()
            .subscribe((categoryResult)=>(
              
              this.categories = categoryResult,
              this.defaultCategories = categoryResult,
              // Store the default categories
              console.log(categoryResult  )

              ))
  }

  addCategory(){
    this.router.navigate(['site/add-category']);
  }
  deleteCategory(): void {
    console.log(this.selectedItem)
    this.categoryService.deleteCategory(this.selectedItem).subscribe(() => {
      console.log('Category deleted!');
      // Refresh the categories list after deletion
      this.getCategories();
    });
  }

}
