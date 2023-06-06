
import { Component, OnInit } from '@angular/core';
import { RoleService } from 'src/app/core/services/role.service';
import { UserService } from 'src/app/core/services/user.service';

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.css']
})
export class CategoriesComponent implements OnInit {

  toDo:any[]=["johal","Sandeep"];
  
  constructor(private roleApi:RoleService, private userApi:UserService) { }

  ngOnInit(): void {
    
    this.userApi.getAll().subscribe((result)=>{
      console.log(result);
    })
  }

  
  deleteCategory(): void {
    // Perform delete action here
    console.log('Item deleted!');
  }

}
