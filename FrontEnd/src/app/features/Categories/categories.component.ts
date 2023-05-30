
import { Component, OnInit } from '@angular/core';
import { RoleService } from 'src/app/core/services/role.service';

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.css']
})
export class CategoriesComponent implements OnInit {

  toDo:any[]=["johal","Sandeep"];
  
  constructor(private roleApi:RoleService) { }

  ngOnInit(): void {
    
  }

  
  deleteCategory(): void {
    // Perform delete action here
    console.log('Item deleted!');
  }

}
