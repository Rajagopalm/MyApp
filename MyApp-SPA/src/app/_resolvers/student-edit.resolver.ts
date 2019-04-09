import {Injectable} from '@angular/core';
import {Student} from '../_models/student';
import {Resolve, Router, ActivatedRouteSnapshot} from '@angular/router';
import { StudentService } from '../_services/student.service';
import { AlertifyService } from '../_services/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { AuthService } from '../_services/auth.service';

@Injectable()
export class StudentEditResolver implements Resolve<Student> {
    constructor(private studentService: StudentService, private router: Router,
        private alertify: AlertifyService, private authService: AuthService) {}

    resolve(route: ActivatedRouteSnapshot): Observable<Student> {
        return this.studentService.getStudent(this.authService.decodedToken.nameid).pipe(
            catchError(error => {
                this.alertify.error('Problem retrieving your data');
                this.router.navigate(['/students']);
                return of(null);
            })
        );
    }
}
