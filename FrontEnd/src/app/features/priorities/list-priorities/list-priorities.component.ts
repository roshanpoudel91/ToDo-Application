import { Component, OnInit } from '@angular/core';
<<<<<<< HEAD
=======
import { Router } from '@angular/router';
import { Priority } from 'src/app/core/models/Priority';
import { PriorityService } from 'src/app/core/services/priority.service';
import { faTable, faEdit, faTrash } from '@fortawesome/free-solid-svg-icons';

>>>>>>> 488f9320bcf4ca92ff946fa0e26d33be8adc4c64

@Component({
  selector: 'app-list-priorities',
  templateUrl: './list-priorities.component.html',
  styleUrls: ['./list-priorities.component.css']
})
export class ListPrioritiesComponent implements OnInit {

<<<<<<< HEAD
  constructor() { }

  ngOnInit(): void {
  }

=======
  faTable = faTable;
  faEdit = faEdit;
  faTrash = faTrash;
  priorities: Priority[] = [];
  deletepriorityId:number = 0;

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

  goToDelete(id:number){
    this.deletepriorityId = id;
  }

  getPriorities():void{
        this.priorityService
            .getPriorities()
            .subscribe((priorityResult)=>(this.priorities = priorityResult))
  }

  addPriority(){
    this.router.navigate(['site/add-priority']);
  }

  deletePriority(): void {
    console.log("priority_id in compontent", this.deletepriorityId);
    this.priorityService.deletePriority(this.deletepriorityId).subscribe(() => {
      console.log('Priority deleted!');
      // Refresh the priorities list after deletion
      this.getPriorities();
    });
  }


>>>>>>> 488f9320bcf4ca92ff946fa0e26d33be8adc4c64
}