import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {MovieList} from "./models/MovieModels";

@Injectable({
  providedIn: 'root'
})
export class MovieService {

  constructor(private http:HttpClient) { }

  onMovieLoad(){
    return this.http.get<MovieList[]>('https://localhost:5001/api/movie');
  }
}
