import { Component, OnInit } from '@angular/core';
import { Student } from '../../_models/student';
import { StudentService } from '../../_services/student.service';
import { AlertifyService } from '../../_services/alertify.service';
import { ActivatedRoute } from '../../../../node_modules/@angular/router';
import { Pagination, PaginatedResult } from '../../_models/pagination';

@Component({
  selector: 'app-student-list',
  templateUrl: './student-list.component.html',
  styleUrls: ['./student-list.component.css']
})
export class StudentListComponent implements OnInit {
  students: Student[];
  student: Student = JSON.parse(localStorage.getItem('student'));
  genderList = [{value: 'male', display: 'Males'}, {value: 'female', display: 'Females'}];
  studentParams: any = {};
  pagination: Pagination;

  constructor(private studentService: StudentService, private alertify: AlertifyService,
    private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.students = data['students'].result;
      this.pagination = data['students'].pagination;
    });

    this.studentParams.gender = this.student.gender === 'female' ? 'male' : 'female';
    this.studentParams.minAge = 18;
    this.studentParams.maxAge = 99;
    this.studentParams.orderBy = 'lastActive';
  }

  pageChanged(event: any): void {
    this.pagination.currentPage = event.page;
    this.loadStudents();
  }

  resetFilters() {
    this.studentParams.gender = this.student.gender === 'female' ? 'male' : 'female';
    this.studentParams.minAge = 18;
    this.studentParams.maxAge = 99;
    this.loadStudents();
  }

  loadStudents() {
    this.studentService.getStudents(this.pagination.currentPage, this.pagination.itemsPerPage, this.studentParams)
      .subscribe((res: PaginatedResult<Student[]>) => {
        this.students = res.result;
        this.pagination = res.pagination;
    }, error => {
      this.alertify.error(error);
    });
  }

}
