import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Contact } from '../contact.model';
import { ContactService } from '../contact.service'

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.css']
})
export class ContactComponent implements OnInit {

  constructor(private ContactService: ContactService, private router: Router) { }

  columnsToDisplay = ['firstName','lastName','email','street','city','state','zip','phoneNumber','contactFrequency','contactMethod'];

  contacts: Contact[];

  ngOnInit(): void {
    this.contacts = new Array<Contact>();
    this.getContacts()
  }

  getContacts(): void {
    this.ContactService.getContacts().subscribe((data: Contact[]) => this.contacts = data);
  }

  onRowClick(row): void {
    this.router.navigate[`/edit/${row.contactId}`]
  }


}
