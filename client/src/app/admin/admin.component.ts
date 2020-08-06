import { Component, OnInit } from '@angular/core';
import {MovieList} from "../shared/models/MovieModels";
import {MovieService} from "../shared/movie.service";
import {AdminService} from "../shared/admin.service";
import {FormArray, FormControl, FormGroup, NgForm, Validators} from "@angular/forms";
import {HttpClient} from "@angular/common/http";
import {ToastrModule, ToastrService} from "ngx-toastr";
import {Observable} from "rxjs";
import {Login} from "../shared/models/AccountModels";
import {AccountService} from "../shared/account.service";

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.scss']
})
export class AdminComponent implements OnInit {
  movies: MovieList[];
  editMode = false;
  index = 0;
  currentUser$: Observable<Login>

  constructor(private movieService: MovieService, private accountService: AccountService,private adminService: AdminService, private http: HttpClient, private toast: ToastrService) { }

  ngOnInit(): void {
    this.currentUser$ = this.accountService.currentUser$;
    this.movieService.onMovieLoad().subscribe(res => {
      console.log(res);
      this.movies = res;
    })
  }

  onEdit(movie: MovieList) {
    this.index = this.movies.indexOf(movie)
  }

  onDelete(movie: MovieList) {
    const index = this.movies.indexOf(movie)
    if (index > -1) {
      this.movies.splice(index, 1);
    }
    this.adminService.onDelete(movie).subscribe(res => {
      console.log(res);
    })
  }

  onEditSubmit(edit: NgForm, movie: MovieList) {
    const index = this.movies.indexOf(movie)
    if (index > -1) {
    }
    this.http.put('https://localhost:5001/api/movie/edit', movie).subscribe(res => {
      this.toast.success("You have Edited an Item");
      console.log(res);
    })
  }

  onAdd(add: NgForm) {
    // this.movies.push(...add.value);
    // this.movies.push(...add.value);
    console.log();
    this.http.post('https://localhost:5001/api/movie', add.value).subscribe(res => {
      this.toast.success("You have Added an Item");
      console.log(res);
    })
  }
}
