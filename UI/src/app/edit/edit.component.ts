import { Component, OnInit,ViewChild  } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ContactFrequency } from '../contact-frequency.model';
import { ContactMethod } from '../contact-method.model';
import { Contact } from '../contact.model';
import { State } from '../state.model';
import { ContactService } from '../contact.service'
import { FormBuilder } from '@angular/forms';
import { NgForm } from '@angular/forms';


@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {

  @ViewChild('contactForm', { static: false }) contactForm: NgForm;

  id: number;

  contact: Contact;
  states: State[];
  contactFreq: ContactFrequency[];
  contactMethod: ContactMethod[];

  constructor(private route: ActivatedRoute, private ContactService: ContactService, private router: Router) { 

  }

  ngOnInit(): void {
    this.route.params.subscribe(params => {this.id = params['id'];});
    
    this.contact = new Contact;

    this.ContactService.getContact(this.id).subscribe((data: Contact) => this.contact = data);
    this.ContactService.getStates().subscribe((data: State[]) => this.states = data);
    this.ContactService.getContactFreq().subscribe((data: ContactFrequency[]) => this.contactFreq = data);
    this.ContactService.getContactMethod().subscribe((data: ContactMethod[]) => this.contactMethod = data);
  }

  onSubmit(){
    this.ContactService.updateContact(this.contact).subscribe(data => this.router.navigate(['/contact']));
  }

  delete(){
    this.ContactService.deleteContact(this.contact.contactId).subscribe(data => this.router.navigate(['/contact']));
  }

}
