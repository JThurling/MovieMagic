import { Component, OnInit } from '@angular/core';
import {Observable} from "rxjs";
import {NgForm} from "@angular/forms";
import {AccountService} from "../account.service";
import {Router} from "@angular/router";
import {Login} from "../models/AccountModels";

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss']
})
export class NavBarComponent implements OnInit {
  currentUser$: Observable<Login>;

  constructor(private accountService: AccountService, private router: Router) { }

  ngOnInit(): void {
    this.currentUser$ = this.accountService.currentUser$;
  }

  onSubmit(loginForm: NgForm) {
    console.log(loginForm.value);
    this.accountService.onLogin(loginForm.value);
    this.router.navigate(['/shop'])
  }

  onLogout() {
    window.location.reload();
  }
}
