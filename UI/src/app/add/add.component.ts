import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ContactFrequency } from '../contact-frequency.model';
import { ContactMethod } from '../contact-method.model';
import { Contact } from '../contact.model';
import { ContactService } from '../contact.service';
import { State } from '../state.model';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css']
})
export class AddComponent implements OnInit {

  contact: Contact;
  states: State[];
  contactFreq: ContactFrequency[];
  contactMethod: ContactMethod[];

  constructor(private ContactService: ContactService, private router: Router) {

   }

  ngOnInit(): void {
    this.contact = new Contact;

    this.ContactService.getStates().subscribe((data: State[]) => this.states = data);
    this.ContactService.getContactFreq().subscribe((data: ContactFrequency[]) => this.contactFreq = data);
    this.ContactService.getContactMethod().subscribe((data: ContactMethod[]) => this.contactMethod = data);
  }

  onSubmit(){
    this.ContactService.addContact(this.contact).subscribe(data => this.router.navigate(['/contact']))
  }

}
