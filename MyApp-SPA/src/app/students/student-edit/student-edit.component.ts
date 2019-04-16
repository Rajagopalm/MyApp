
import { Component, OnInit, ViewChild, HostListener } from '@angular/core';
import { Student } from '../../_models/student';
import { City } from '../../_models/city';

import { Router, ActivatedRoute } from '@angular/router';
import { AlertifyService } from '../../_services/alertify.service';
import { NgForm } from '@angular/forms';
import { StudentService } from '../../_services/student.service';
import { AuthService } from '../../_services/auth.service';

@Component({
  selector: 'app-student-edit',
  templateUrl: './student-edit.component.html',
  styleUrls: ['./student-edit.component.css']
})

export class StudentEditComponent implements OnInit {
    @ViewChild('editForm') editForm: NgForm;
    student: Student;
    cities: City[];
    photoUrl: string;
    @HostListener('window:beforeunload', ['$event'])
    unloadNotification($event: any) {
      if (this.editForm.dirty) {
        $event.returnValue = true;
      }
    }

    constructor(private router: Router, private route: ActivatedRoute, private alertify: AlertifyService,
      private studentService: StudentService, private authService: AuthService) { }

    ngOnInit() {
      this.route.data.subscribe(data => {
        this.student = data['student'];
      });
      this.authService.currentPhotoUrl.subscribe(photoUrl => this.photoUrl = photoUrl);

      this.getCities();
    }

    getCities() {
      this.studentService.getCities().subscribe((cities: City[]) => this.cities = cities);
    }

    submit() {

      if (this.student.id) {

        this.studentService.updateStudent(this.student).subscribe(next => {
          this.alertify.success('Profile updated successfully');
          this.editForm.reset(this.student);
        }, error => {
          this.alertify.error(error);
        });

      } else {

        this.studentService.insertStudent(this.student).subscribe(next => {
          this.alertify.success('Profile updated successfully');
          this.editForm.reset(this.student);
        }, error => {
          this.alertify.error(error);
        });

      }
  }

  cancel(event: Event) {
    event.preventDefault();
    this.router.navigate(['/']);
  }

  delete(event: Event) {
    event.preventDefault();
    this.studentService.deleteStudent(this.student).subscribe(next => {
      this.alertify.success('Profile Deleted successfully');
      this.router.navigate(['/students']);
    }, error => {
      this.alertify.error(error);
    });
  }




  }
