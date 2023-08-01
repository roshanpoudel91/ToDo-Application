import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Priority } from 'src/app/core/models/Priority';
import { PriorityService } from 'src/app/core/services/priority.service';

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
    private router : Router,
    private priorityService: PriorityService
    ) { }

  ngOnInit(): void {

   

    const priorityId = parseInt(this.route.snapshot.paramMap.get('id')!, 10);
    //if priorityId is present in url, form will act as update form otherwise it will act as add form.
    if (priorityId) {
      this.priority_button = "UPDATE";
      this.priority_add = "Edit Priority";
      this.getPriority(priorityId);
    }

  }

  back(): void {
    // this.location.back();
    this.router.navigate(['site/priority'])
  }

  
  addPriority(form: NgForm) {
    // form:NgForm parameter has to be deleted after api implemented

    if (form.invalid) { this.submitted=true;return; }

    if (this.model) {
      console.log(this.model);
      //if priorityId is present, it will update form otherwise it will add form.
      if (this.model.priorityId) {
        this.priorityService.updatePriority(this.model)
          .subscribe(() => this.back());

      } else {

        this.priorityService.addPriority(this.model)
          .subscribe(() => this.back());

      }

    }
  }

  getPriority(priorityId: number): void {
    // get the category priorityId from the URL
    // const priorityId = parseInt(this.route.snapshot.paramMap.get('priorityId')!, 10);
    console.log("priority_id", priorityId);
    this.priorityService
      .getPriority(priorityId)
      .subscribe((priorityResult) => {
        this.model = priorityResult;
        console.log(this.model);

      });
  }


}
