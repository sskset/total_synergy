import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddContactToProjectComponent } from './add-contact-to-project.component';

describe('AddContactToProjectComponent', () => {
  let component: AddContactToProjectComponent;
  let fixture: ComponentFixture<AddContactToProjectComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddContactToProjectComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddContactToProjectComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
