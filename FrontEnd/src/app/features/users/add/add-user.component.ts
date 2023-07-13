import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from 'src/app/core/models/user';
import { UserService } from 'src/app/core/services/user.service';

@Component({
  selector: 'app-add-user',
  templateUrl: './add-user.component.html',
  styleUrls: ['./add-user.component.css']
})
export class AddUserComponent implements OnInit {

  model: User = {} as User;
  form!: NgForm;
  user_button: string = "SAVE";
  user_add: string = "Add User";
  submitted:boolean = false;

  constructor(
    private route: ActivatedRoute,
    private datePipe: DatePipe,
    private router : Router,
    private userService: UserService
    ) { }

  ngOnInit(): void {

    const id = this.route.snapshot.paramMap.get('id')!;
    
    //if id is present in url, form will act as update form otherwise it will act as add form.
    if (id) {
      this.user_button = "UPDATE";
      this.user_add = "Edit User";
      this.getUser(id);
    }

  }

  back(): void {
    // this.location.back();
    this.router.navigate(['site/user'])
  }

  
  addUser(form: NgForm) {
    // form:NgForm parameter has to be deleted after api implemented

    if (form.invalid) { this.submitted=true;return; }

    if (this.model) {
      console.log(this.model);
     

      //if id is present, it will update form otherwise it will add form.
      if (this.model.id) {
        // const requiredField = {UserViewId:"",Password:"Test@123",ConfirmPassword:"Test@123",AccessToken:""}

        // this.model.UserviewId = "";
        // this.model.Password = "";
        // this.model.ConfirmPassword = "";
        // this.model.AccessToken = "";

        
        this.userService.update(this.model.id,this.model)
          .subscribe(() => this.back());

      } else {

        const requiredField = {id:"",UserViewId:"",Password:"Test@123",ConfirmPassword:"Test@123",AccessToken:""}

        this.model = {...this.model, ...requiredField}

        this.userService.create(this.model)
          .subscribe(() => this.back());

      }

    }
  }

  getUser(id: any): void {
    // get the category id from the URL
    // const id = parseInt(this.route.snapshot.paramMap.get('id')!, 10);
    console.log("user_id", id);
    this.userService
      .getById(id.toString())
      .subscribe((userResult) => {
        this.model = userResult;
        console.log(this.model);

      });
  }
}
