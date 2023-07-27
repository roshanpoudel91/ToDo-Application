import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { DatePipe, Location } from '@angular/common';
import { Category } from 'src/app/core/models/category';
import { CategoryService } from 'src/app/core/services/category.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-add-category',
  templateUrl: './add-category.component.html',
  styleUrls: ['./add-category.component.css']
})
export class AddCategoryComponent implements OnInit {
  model: Category = {} as Category;
  form!: NgForm;
  category_button: string = "SAVE";
  category_add: string = "Add Category";
  submitted:boolean = false;

  constructor(private categoryService: CategoryService,
    private location: Location,
    private route: ActivatedRoute,
    private datePipe: DatePipe,
    private router : Router
  ) { }

  ngOnInit(): void {
    const id = parseInt(this.route.snapshot.paramMap.get('id')!, 10);
    //if id is present in url, form will act as update form otherwise it will act as add form.
    if (id) {
      this.category_button = "UPDATE";
      this.category_add = "Edit Category";
      this.getCategory(id);
    }
  }

  back(): void {
    // this.location.back();
    this.router.navigate(['site/category'])
  }

  addCategory(form: NgForm) {
    // form:NgForm parameter has to be deleted after api implemented

    if (form.invalid) { this.submitted=true;return; }

    if (this.model) {
      console.log(this.model);
      //if id is present, it will update form otherwise it will add form.
      if (this.model.categoryId) {
        this.categoryService.updateCategory(this.model)
          .subscribe(() => this.back());

      } else {

        this.categoryService.addCategory(this.model)
          .subscribe(() => this.back());

      }

    }
  }

  getCategory(id: number): void {
    // get the category id from the URL
    // const id = parseInt(this.route.snapshot.paramMap.get('id')!, 10);
    console.log("category_id", id);
    this.categoryService
      .getCategory(id)
      .subscribe((categoryResult) => {
        categoryResult.date = this.datePipe.transform(categoryResult.date, 'yyyy-MM-dd');
        this.model = categoryResult;
        console.log(this.model);

      });


  }

}
