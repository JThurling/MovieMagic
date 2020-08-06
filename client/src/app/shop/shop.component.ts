import { Component, OnInit } from '@angular/core';
import {MovieService} from "../shared/movie.service";
import {MovieList} from "../shared/models/MovieModels";
import {AccountService} from "../shared/account.service";
import {Observable} from "rxjs";
import {Login} from "../shared/models/AccountModels";
import {ShopService} from "../shared/shop.service";
import {ToastrService} from "ngx-toastr";

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {
  movies: MovieList[];
  basket: MovieList[] = [];
  price = 0;
  currentUser$: Observable<Login>;

  constructor(private movieService: MovieService, private toast: ToastrService,private account: AccountService ,private shopService: ShopService) { }

  ngOnInit(): void {
    this.currentUser$ = this.account.currentUser$;
    this.movieService.onMovieLoad().subscribe(res => {
      console.log(res);
      this.movies = res;
    })
  }

  onAddToBasket(movie: MovieList) {
    console.log(movie);
    this.basket.push(movie);
    this.price += movie.price;
  }

  onCheckOut(basket: MovieList[], email: string) {
    const basketValue = {
      email: email,
      movies: basket
    }
    console.log(basketValue);
    this.shopService.onOrder(basketValue).subscribe(res => {
      this.basket.splice(0, basket.length);
      this.toast.success("Thank you for your purchase");
      console.log(res);
    })
  }
}
