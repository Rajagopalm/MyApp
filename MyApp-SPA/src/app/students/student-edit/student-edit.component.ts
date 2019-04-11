import { Component, OnInit, ViewChild, HostListener } from '@angular/core';
import { Student } from '../../_models/student';
import { ActivatedRoute } from '@angular/router';
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
    photoUrl: string;
    @HostListener('window:beforeunload', ['$event'])
    unloadNotification($event: any) {
      if (this.editForm.dirty) {
        $event.returnValue = true;
      }
    }

    constructor(private route: ActivatedRoute, private alertify: AlertifyService,
      private studentService: StudentService, private authService: AuthService) { }

    ngOnInit() {
      this.route.data.subscribe(data => {
        this.student = data['student'];
      });
      this.authService.currentPhotoUrl.subscribe(photoUrl => this.photoUrl = photoUrl);
    }

    updateStudent() {
      this.studentService.updateStudent(this.authService.decodedToken.nameid, this.student).subscribe(next => {
        this.alertify.success('Profile updated successfully');
        this.editForm.reset(this.student);
      }, error => {
        this.alertify.error(error);
      });
    }
  }
