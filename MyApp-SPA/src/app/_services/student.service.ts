import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Student } from '../_models/student';
import { PaginatedResult } from '../_models/pagination';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class StudentService {



  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getStudents(page?, itemsPerPage?, studentParams?): Observable<PaginatedResult<Student[]>> {
    const paginatedResult: PaginatedResult<Student[]> = new PaginatedResult<Student[]>();

    let params = new HttpParams();

    if (page != null && itemsPerPage != null) {
      params = params.append('pageNumber', page);
      params = params.append('pageSize', itemsPerPage);
    }

     if (studentParams != null) {
      params = params.append('gender', studentParams.gender);
    //  params = params.append('orderBy', studentParams.orderBy);
     }

    return this.http.get<Student[]>(this.baseUrl + 'students', { observe: 'response', params})
      .pipe(
        map(response => {
          paginatedResult.result = response.body;
          if (response.headers.get('Pagination') != null) {
            paginatedResult.pagination = JSON.parse(response.headers.get('Pagination'));
          }
          return paginatedResult;
        })
      );
  }

  getStudent(id): Observable<Student> {
    return this.http.get<Student>(this.baseUrl + 'students/' + id);
  }

  updateStudent(id: number, student: Student) {
    return this.http.put(this.baseUrl + 'students/' + id, student);
  }

}
