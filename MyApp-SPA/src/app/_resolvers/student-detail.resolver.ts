import {Injectable} from '@angular/core';
import {Student} from '../_models/student';
import {Resolve, Router, ActivatedRouteSnapshot} from '@angular/router';
import { StudentService } from '../_services/student.service';
import { AlertifyService } from '../_services/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable()
export class StudentDetailResolver implements Resolve<Student> {
    constructor(private studentService: StudentService, private router: Router,
        private alertify: AlertifyService) {}

    resolve(route: ActivatedRouteSnapshot): Observable<Student> {
        return this.studentService.getStudent(route.params['id']).pipe(
            catchError(error => {
                this.alertify.error('Problem retrieving data');
                this.router.navigate(['/students']);
                return of(null);
            })
        );
    }
}
