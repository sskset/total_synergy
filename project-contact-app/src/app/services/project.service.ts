import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';

const headers = new HttpHeaders({
  'Content-Type': 'application/json'
});

@Injectable({
  providedIn: 'root'
})
export class ProjectService {
  svcUrl = `${environment.apiUrl}/projects`;

  constructor(private http: HttpClient) {}

  getProjects() {
    return this.http.get(this.svcUrl);
  }

  createProject(projectName: string) {
    return this.http.post(this.svcUrl, {
      ProjectName: projectName
    });
  }

  deleteProject(projectId: number) {
    return this.http.delete(`${this.svcUrl}/${projectId}`);
  }

  addContact(projectId: number, contactId: number) {
    return this.http.post(`${this.svcUrl}/${projectId}/contacts`, {
      ContactId: contactId
    });
  }

  removeContact(projectId: number, contactId: number) {
    return this.http.delete(
      `${this.svcUrl}/${projectId}/contacts/${contactId}`
    );
  }

  getContacts(projectId: number) {
    return this.http.get(`${this.svcUrl}/${projectId}/contacts`);
  }
}
