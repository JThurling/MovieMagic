import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {NgForm} from "@angular/forms";
import {BehaviorSubject, Observable, ReplaySubject, Subject} from "rxjs";
import {Login} from "./models/AccountModels";
import {map} from "rxjs/operators";

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  private currentUserSource: ReplaySubject<Login> = new ReplaySubject<Login>(null);
  currentUser$ = this.currentUserSource.asObservable();

  constructor(private http: HttpClient) { }

  onLogin(values: NgForm) {
    return this.http.post<Login>('https://localhost:5001/api/account/login', values).subscribe(res => {
      console.log(res);
      this.currentUserSource.next(res);
    })
  }

  onRegister(values: NgForm) {
    return this.http.post('https://localhost:5001/api/account/register', values);
  }

  isLoggedIn(): boolean {
    return this.currentUser$ === null;
  }


}
