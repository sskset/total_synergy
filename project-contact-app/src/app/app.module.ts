import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ProjectListComponent } from './project-list/project-list.component';
import { ContactListComponent } from './contact-list/contact-list.component';
import { UiModule } from './ui/ui.module';
import { HomeComponent } from './home/home.component';
import { HttpClientModule } from '@angular/common/http';
import { ProjectDetailComponent } from './project-detail/project-detail.component';
import { CreateProjectComponent } from './create-project/create-project.component';
import { CreateContactComponent } from './create-contact/create-contact.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AddContactToProjectComponent } from './add-contact-to-project/add-contact-to-project.component';
@NgModule({
  declarations: [
    AppComponent,
    ProjectListComponent,
    ContactListComponent,
    HomeComponent,
    ProjectDetailComponent,
    CreateProjectComponent,
    CreateContactComponent,
    AddContactToProjectComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    UiModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {}
