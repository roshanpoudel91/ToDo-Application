import { Component, OnInit } from '@angular/core';
import { RoleService } from 'src/app/core/services/role.service';
import { UserService } from 'src/app/core/services/user.service';

@Component({
  selector: 'app-temporary-data',
  templateUrl: './temporary-data.component.html',
  styleUrls: ['./temporary-data.component.css']
})
export class TemporaryDataComponent implements OnInit {

  

  toDo:any[]=["Johal","Sandeep","Inder"];
  
  constructor(private roleApi:RoleService, private userApi:UserService) { }

  ngOnInit(): void {
    
    this.userApi.getAll().subscribe((result)=>{
      console.log(result);
    })
  }

  
  deletePriority(): void {
    // Perform delete action here
    console.log('Priority deleted!');
  }


}
