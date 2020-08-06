import {Component, OnInit} from '@angular/core';
import {Observable} from "rxjs";
import {Login} from "./shared/models/AccountModels";
import {AccountService} from "./shared/account.service";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit{
  title = 'client';
  currentUser$: Observable<Login>;

  constructor(private accountService: AccountService) {
  }

  ngOnInit(): void {
    this.currentUser$ = this.accountService.currentUser$;
  }

}
