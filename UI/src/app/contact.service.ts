import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { Contact } from './contact.model'
import { HttpHeaders } from '@angular/common/http';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type':  'application/json'
  })
};

// UPDATE THIS TO THE API URL FROM THE POWERSHELL WINDOW
const baseUrl = 'https://localhost:5001';

@Injectable({
  providedIn: 'root'
})


export class ContactService {

  constructor(private http: HttpClient) { }

  getContacts(){
    return this.http.get(baseUrl + '/api/contacts');
  }

  getContact(id: number){
    return this.http.get(baseUrl + `/api/contacts/${id}`);
  }

  getStates(){
    return this.http.get(baseUrl + '/api/states');
  }

  getContactFreq(){
    return this.http.get(baseUrl + '/api/ContactFrequencies');
  }

  getContactMethod(){
    return this.http.get(baseUrl + '/api/ContactMethods');
  }

  updateContact(data: Contact){
    return this.http.put(baseUrl + '/api/contacts', data);
  }

  deleteContact(id: number){
    return this.http.delete(baseUrl + `/api/contacts/${id}`)
  }

  addContact(data: Contact){
    return this.http.post(baseUrl + `/api/contacts`, data)
  }
}

