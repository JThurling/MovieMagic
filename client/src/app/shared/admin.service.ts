import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class AdminService {

  constructor(private http: HttpClient) { }

  onDelete(values: any) {
    return this.http.post('https://localhost:5001/api/movie/delete', values);
  }
}
