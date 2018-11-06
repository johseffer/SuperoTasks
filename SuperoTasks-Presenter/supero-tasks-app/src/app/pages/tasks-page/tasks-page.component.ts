import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, MatTableDataSource } from '@angular/material';
import { TasksService } from '../../service/tasks.service';
import { Router } from '@angular/router';
@Component({
  selector: 'app-tasks-page',
  templateUrl: './tasks-page.component.html',
  styleUrls: ['./tasks-page.component.scss']
})
export class TasksPageComponent implements OnInit {

  constructor(public tasksService: TasksService, private router: Router) {
  }

  ngOnInit() {
  }
}
