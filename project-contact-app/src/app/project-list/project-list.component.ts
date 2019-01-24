import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { ProjectService } from '../services/project.service';
import { Router } from '@angular/router';

declare var $: any;

@Component({
  selector: 'app-project-list',
  templateUrl: './project-list.component.html',
  styleUrls: ['./project-list.component.css']
})
export class ProjectListComponent implements OnInit {
  projects;
  selectedProject;

  @ViewChild('md') md;

  constructor(private projectService: ProjectService, private router: Router) {}

  ngOnInit() {
    this.projectService.getProjects().subscribe(data => {
      console.log(data);
      this.projects = data;
    });
  }

  onDelete() {
    if (this.selectedProject) {
      this.projectService
        .deleteProject(this.selectedProject.projectId)
        .subscribe(data => {
          console.log(data);

          this.projects = this.projects.filter(
            x => x.projectId !== this.selectedProject.projectId
          );

          $('#exampleModalCenter').modal('hide');
        });
    }
  }
}
