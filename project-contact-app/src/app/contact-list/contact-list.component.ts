import { Component, OnInit } from '@angular/core';
import { ContactService } from '../services/contact.service';

declare var $: any;

@Component({
  selector: 'app-contact-list',
  templateUrl: './contact-list.component.html',
  styleUrls: ['./contact-list.component.css']
})
export class ContactListComponent implements OnInit {
  contacts;
  selectedContact;
  constructor(private contactService: ContactService) {}

  ngOnInit() {
    this.contactService.getContacts().subscribe(data => {
      console.log(data);
      this.contacts = data;
    });
  }

  onDelete() {
    if (this.selectedContact) {
      this.contactService
        .deleteContact(this.selectedContact.contactId)
        .subscribe(data => {
          console.log(data);

          this.contacts = this.contacts.filter(
            x => x.contactId !== this.selectedContact.contactId
          );

          $('#exampleModalCenter').modal('hide');
        });
    }
  }
}
