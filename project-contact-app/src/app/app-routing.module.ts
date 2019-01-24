import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProjectListComponent } from './project-list/project-list.component';
import { ContactListComponent } from './contact-list/contact-list.component';
import { HomeComponent } from './home/home.component';
import { CreateProjectComponent } from './create-project/create-project.component';
import { CreateContactComponent } from './create-contact/create-contact.component';
import { AddContactToProjectComponent } from './add-contact-to-project/add-contact-to-project.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'home',
    pathMatch: 'full'
  },
  // {
  //   path: '**',
  //   redirectTo: 'home',
  //   pathMatch: 'full'
  // },
  {
    path: 'projects',
    component: ProjectListComponent
  },
  {
    path: 'create-project',
    component: CreateProjectComponent
  },
  {
    path: 'contacts',
    component: ContactListComponent
  },
  {
    path: 'create-contact',
    component: CreateContactComponent
  },
  {
    path: 'home',
    component: HomeComponent
  },
  {
    path: 'add-contact-to-project',
    component: AddContactToProjectComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
