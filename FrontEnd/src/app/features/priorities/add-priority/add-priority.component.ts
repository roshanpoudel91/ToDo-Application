import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Priority } from 'src/app/core/models/Priority';

@Component({
  selector: 'app-add-priority',
  templateUrl: './add-priority.component.html',
  styleUrls: ['./add-priority.component.css']
})
export class AddPriorityComponent implements OnInit {

  model: Priority = {} as Priority;
  form!: NgForm;
  priority_button: string = "SAVE";
  priority_add: string = "Add Priority";
  submitted:boolean = false;

  constructor(
    private route: ActivatedRoute,
    private datePipe: DatePipe,
    private router : Router
    ) { }

  ngOnInit(): void {

   

    const id = parseInt(this.route.snapshot.paramMap.get('id')!, 10);
    //if id is present in url, form will act as update form otherwise it will act as add form.
    if (id) {
      this.priority_button = "UPDATE";
      this.priority_add = "Edit Priority";
      this.getPriority(id);
    }

  }

  back(): void {
    // this.location.back();
    this.router.navigate(['site/category'])
  }

  
  addPriority(form: NgForm) {
    // form:NgForm parameter has to be deleted after api implemented

    if (form.invalid) { this.submitted=true;return; }

    if (this.model) {
      console.log(this.model);
      //if id is present, it will update form otherwise it will add form.
      if (this.model.id) {
        // this.categoryService.updateCategory(this.model)
        //   .subscribe(() => this.back());

      } else {

        // this.categoryService.addCategory(this.model)
        //   .subscribe(() => this.back());

      }

    }
  }

  getPriority(id: number): void {
    // get the category id from the URL
    // const id = parseInt(this.route.snapshot.paramMap.get('id')!, 10);
    console.log("priority_id", id);
    // this.priorityService
    //   .getCategory(id)
    //   .subscribe((priorityResult) => {
    //     priorityResult.date = this.datePipe.transform(categoryResult.date, 'yyyy-MM-dd');
    //     this.model = categoryResult;
    //     console.log(this.model);

    }

}
