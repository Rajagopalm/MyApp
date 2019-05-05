import { Component, Input, OnInit, ChangeDetectionStrategy } from '@angular/core';

import { Student } from '../../_models/Student';
import { Sorter } from '../../_services/sorter';
import { Router } from '@angular/router';
import { StudentService } from '../../_services/student.service';
import { AlertifyService } from '../../_services/alertify.service';
@Component({
  selector: 'app-student-grid',
  templateUrl: './student-grid.component.html',
  // When using OnPush detectors, then the framework will check an OnPush
  // component when any of its input properties changes, when it fires
  // an event, or when an observable fires an event ~ Victor Savkin (Angular Team)
  changeDetection: ChangeDetectionStrategy.OnPush
})

export class StudentGridComponent implements OnInit {

  @Input() students: Student[] = [];

  constructor(private studentService: StudentService, private alertify: AlertifyService,private sorter: Sorter,  private router: Router) { }

  ngOnInit() {

  }

  sort(prop: string) {
      this.sorter.sort(this.students, prop);
  }

  openForEdit(studentID: number) {
    this.router.navigate(['/student/edit/' + studentID]);
  }

  onDeleteStudent(student: Student) {
    if (student.id != null)
    {
      this.studentService.deleteStudent(student).subscribe(res => {
        this.alertify.success('Student Deleted successfully');
        this.router.navigate(['/students']);
    }, error => {
      this.alertify.error(error);
    });


    }
  }



}
