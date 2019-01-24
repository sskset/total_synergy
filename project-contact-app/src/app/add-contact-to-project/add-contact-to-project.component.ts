import { Component, OnInit } from '@angular/core';
import { ProjectService } from '../services/project.service';
import { ContactService } from '../services/contact.service';

@Component({
  selector: 'app-add-contact-to-project',
  templateUrl: './add-contact-to-project.component.html',
  styleUrls: ['./add-contact-to-project.component.css']
})
export class AddContactToProjectComponent implements OnInit {
  projects;
  selectedProject;
  contacts;
  includedContacts;
  constructor(
    private projectService: ProjectService,
    private contactService: ContactService
  ) {}

  ngOnInit() {
    this.projectService.getProjects().subscribe(data => {
      this.projects = data;
    });

    this.contactService.getContacts().subscribe(data => {
      this.contacts = data;
      console.log(this.contacts);
    });
  }

  onChangeSelectedProject() {
    console.log(this.selectedProject);
    if (this.selectedProject) {
      this.includedContacts = [];
      this.projectService
        .getContacts(this.selectedProject.projectId)
        .subscribe(data => {
          console.log(data);
          this.includedContacts = data;
        });
    }
  }

  // isChecked(c) {
  //   if (this.includedContacts && this.includedContacts.length > 0 && c) {
  //     for (const x of this.includedContacts) {
  //       if (x.contactId === c.contactId) {
  //         return true;
  //       }
  //     }
  //   }
  //   return false;
  // }

  onChange(e, c) {
    if (this.selectedProject) {
      if (!this.includedContacts) {
        this.includedContacts = [];
      }

      if (e === true) {
        this.projectService
          .addContact(this.selectedProject.projectId, c.contactId)
          .subscribe((data: any) => {
            console.log(data);
            this.includedContacts.push(data['contactId']);
            console.log(this.includedContacts);
          });
      } else {
        this.projectService
          .removeContact(this.selectedProject.projectId, c.contactId)
          .subscribe(data => {
            console.log(data);

            this.includedContacts = this.includedContacts.filter(
              x => x !== c.contactId
            );
          });
      }
    }
  }
}
