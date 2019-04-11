import { Component, OnInit, Input } from '@angular/core';
import { Student } from '../../_models/student';
import { AuthService } from '../../_services/auth.service';
import { StudentService } from '../../_services/student.service';
import { AlertifyService } from '../../_services/alertify.service';

@Component({
  selector: 'app-student-card',
  templateUrl: './student-card.component.html',
  styleUrls: ['./student-card.component.css']
})

export class StudentCardComponent implements OnInit {
  @Input() student: Student;

  constructor(private authService: AuthService, private studentService: StudentService, private alertify: AlertifyService) { }

  ngOnInit() {
  }



}
