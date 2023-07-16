import { State } from './state.model'
import { ContactFrequency } from './contact-frequency.model'
import { ContactMethod } from './contact-method.model'
import { Statement } from '@angular/compiler'

export class Contact {

    contactId: number;
    firstName: string;
    lastName: string;
    email: string;
    street: string;
    city: string;
    zip: string;
    phoneNumber: string;
    state: State;
    contactFrequency:ContactFrequency;
    contactMethod: ContactMethod;

    constructor(){
        this.state = new State;
        this.contactFrequency = new ContactFrequency;
        this.contactMethod = new ContactMethod;
    }
}