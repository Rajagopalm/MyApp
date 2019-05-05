import { City } from '../_models/city';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpParams, HttpResponse, HttpErrorResponse } from '@angular/common/http';
import { Student } from '../_models/student';
import { Observable } from 'rxjs/Observable';


@Injectable({
  providedIn: 'root'
})

export class CityService {

  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getCities(): Observable<City[]> {
        return this.http.get<City[]>(this.baseUrl + 'subdistricts/');
  }

}
