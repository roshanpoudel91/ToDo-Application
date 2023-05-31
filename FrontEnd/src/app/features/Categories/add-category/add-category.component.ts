import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Location } from '@angular/common';
import { Category } from 'src/app/core/models/category';
import { CategoryService } from 'src/app/core/services/category.service';

@Component({
  selector: 'app-add-category',
  templateUrl: './add-category.component.html',
  styleUrls: ['./add-category.component.css']
})
export class AddCategoryComponent implements OnInit {
  model: Category = {} as Category;
  form!: NgForm;
  constructor(private service:CategoryService,
               private location: Location
              ) { }

  ngOnInit(): void {
  }

  back(): void {
    this.location.back();
  }

  addCategory(form:NgForm){
    // form:NgForm parameter has to be deleted after api implemented
    console.log("Adding category: ", form.invalid);
    
    if (form.invalid) { return; }
     
    if (this.model) {
      console.log(this.model);
     this.service.addCategory(this.model)
       .subscribe(() => this.back());
   }
  }

}
