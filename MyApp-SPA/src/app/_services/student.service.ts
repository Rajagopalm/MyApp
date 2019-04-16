import { City } from './../_models/city';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpParams, HttpResponse, HttpErrorResponse } from '@angular/common/http';
import { Student } from '../_models/student';
import { PaginatedResult } from '../_models/pagination';
import { Observable } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { IStudentResponse } from '../_models/IStudentResponse';


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

  updateStudent(student: Student) {
    return this.http.put(this.baseUrl + 'students/' + student.id, student);
  }

  insertStudent(student: Student) {
    return this.http.post<IStudentResponse>(this.baseUrl + 'students/', student)
    .pipe(
         map((data) => {
             console.log('insertStudent status: ' + data.status);
             return data.student;
         }),
         catchError(this.handleError)
     );
  }

  deleteStudent(student: Student): Observable<boolean> {
    return this.http.delete<boolean>(this.baseUrl + '/' + student.id)
               .pipe(catchError(this.handleError));
}

  getCities(): Observable<City[]> {
        return this.http.get<City[]>(this.baseUrl + 'subdistricts/');
  }

  private handleError(error: HttpErrorResponse) {
    console.error('server error:', error);
    if (error.error instanceof Error) {
      let errMessage = error.error.message;
      return Observable.throw(errMessage);
      // Use the following instead if using lite-server
      // return Observable.throw(err.text() || 'backend server error');
    }
    return Observable.throw(error || 'ASP.NET Core server error');
}

}
