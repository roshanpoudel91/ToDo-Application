import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Priority } from 'src/app/core/models/Priority';
import { PriorityService } from 'src/app/core/services/priority.service';
import { faTable, faEdit, faTrash } from '@fortawesome/free-solid-svg-icons';


@Component({
  selector: 'app-list-priorities',
  templateUrl: './list-priorities.component.html',
  styleUrls: ['./list-priorities.component.css']
})
export class ListPrioritiesComponent implements OnInit {

  faTable = faTable;
  faEdit = faEdit;
  faTrash = faTrash;
  priorities: Priority[] = [];

  pageSize = 10; 
  currentPage = 1; 

  constructor(private router : Router, 
              private priorityService: PriorityService) { }

  ngOnInit(): void {
    this.getPriorities();
  }

  goToEdit(id:number){
    console.log('priority_id',id);
    this.router.navigate([`/site/edit-priority/${id}`])
  }

  getPriorities():void{
        this.priorityService
            .getPriorities()
            .subscribe((priorityResult)=>(this.priorities = priorityResult))
  }

  addPriority(){
    this.router.navigate(['site/add-priority']);
  }
  deletePriority(priorityId: number): void {
    this.priorityService.deletePriority(priorityId).subscribe(() => {
      console.log('Priority deleted!');
      // Refresh the categories list after deletion
      this.getPriorities();
    });
  }


}
