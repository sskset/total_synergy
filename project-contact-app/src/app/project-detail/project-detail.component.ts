import { Component, OnInit } from '@angular/core';
import { ProjectService } from '../services/project.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-project-detail',
  templateUrl: './project-detail.component.html',
  styleUrls: ['./project-detail.component.css']
})
export class ProjectDetailComponent implements OnInit {
  form: FormGroup;

  constructor(
    private projectService: ProjectService,
    private fb: FormBuilder,
    private router: Router
  ) {}

  ngOnInit() {
    this.form = this.fb.group({
      projectName: ['', [Validators.required]]
    });
  }

  onSubmit() {
    console.log(this.form.value);

    this.projectService
      .createProject(this.form.controls['projectName'].value)
      .subscribe(data => {
        console.log(data);
        this.router.navigate(['/projects']);
      });
  }
}
