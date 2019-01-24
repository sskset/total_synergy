import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClientModule, HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ContactService {
  svcUrl = `${environment.apiUrl}/contacts`;

  constructor(private http: HttpClient) {}

  getContacts() {
    return this.http.get(this.svcUrl);
  }

  createContact(firstName: string, lastName: string) {
    return this.http.post(this.svcUrl, {
      FirstName: firstName,
      LastName: lastName
    });
  }

  deleteContact(contactId: number) {
    return this.http.delete(`${this.svcUrl}/${contactId}`);
  }
}
