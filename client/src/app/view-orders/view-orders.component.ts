import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Movies, OrderList} from "../shared/models/OrderModel";
import {AccountService} from "../shared/account.service";
import {Login} from "../shared/models/AccountModels";
import {Observable} from "rxjs";

@Component({
  selector: 'app-view-orders',
  templateUrl: './view-orders.component.html',
  styleUrls: ['./view-orders.component.scss']
})
export class ViewOrdersComponent implements OnInit {
  order: OrderList[];
  currentUser$: Observable<Login>;
  price = 0;
  movies: Movies[] = []

  constructor(private http:HttpClient, private account: AccountService ) { }

  ngOnInit(): void {
    this.currentUser$ = this.account.currentUser$;
    this.http.get<OrderList[]>('https://localhost:5001/api/order').subscribe(res => {
      this.order = res;
      console.log(res);
    });

  }

}
