import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Priority } from 'src/app/core/models/Priority';
import { PriorityService } from 'src/app/core/services/priority.service';
import { faTable, faEdit, faTrash } from '@fortawesome/free-solid-svg-icons';
import { User } from 'src/app/core/models/user';
import { UserService } from 'src/app/core/services/user.service';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent implements OnInit {

  faTable = faTable;
  faEdit = faEdit;
  faTrash = faTrash;
  users: User[] = [];
  deleteUserId:string = "";

  pageSize = 10; 
  currentPage = 1; 

  constructor(private router : Router, 
              private userService: UserService) { }

  ngOnInit(): void {
    this.getUsers();
  }

  goToEdit(id:any){
    console.log('user_id',id);
    this.router.navigate([`/site/edit-user/${id}`])
  }

  goToDelete(id:any){
    this.deleteUserId = id.toString();
  }

  getUsers():void{
        this.userService
            .getAll()
            .subscribe((userResult)=>(this.users = userResult))
  }

  addUser(){
    this.router.navigate(['site/add-user']);
  }

  deleteUser(): void {
    console.log("user_id in compontent", this.deleteUserId);
    this.userService.delete(this.deleteUserId).subscribe(() => {
      console.log('User deleted!');
      // Refresh the priorities list after deletion
      this.getUsers();
    });
  }



}
