import { Component, OnInit } from '@angular/core';
import { Category } from 'src/app/core/models/category';

@Component({
  selector: 'app-add-category',
  templateUrl: './add-category.component.html',
  styleUrls: ['./add-category.component.css']
})
export class AddCategoryComponent implements OnInit {
  model: Category = {} as Category;
  constructor() { }

  ngOnInit(): void {
  }

  addCategory(){
    console.log("Adding category");
  }

}
