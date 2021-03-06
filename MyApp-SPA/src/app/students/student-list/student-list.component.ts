import { Component, OnInit } from '@angular/core';
import { Student } from '../../_models/student';
import { StudentService } from '../../_services/student.service';
import { AlertifyService } from '../../_services/alertify.service';
import { ActivatedRoute } from '../../../../node_modules/@angular/router';
import { Pagination, PaginatedResult } from '../../_models/pagination';
import { Sorter } from './../../_services/sorter';
import { CapitalizePipe } from './../../_shared/pipes/capitalize.pipe';
import { DataFilterService } from '../../_services/data-filter.service';
import { Router } from '@angular/router';

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
  filteredStudents: Student[] = [];

  constructor(private studentService: StudentService, private alertify: AlertifyService,
    private route: ActivatedRoute, private router: Router, private dataFilter: DataFilterService) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.students = this.filteredStudents =  data['students'].result;
      this.pagination = data['students'].pagination;
    });


    // this.studentParams.gender =  'male';
    // this.studentParams.orderBy = 'lastActive';
  }

  pageChanged(event: any): void {
    this.pagination.currentPage = event.page;
    this.loadStudents();
  }

  resetFilters() {
    // this.studentParams.gender = 'male';
    this.loadStudents();
  }


  filterChanged(filterText: string) {
    if (filterText && this.students) {
        let props = ['firstName', 'lastName', 'dateOfBirth', 'currentCity', 'fatherName', 'gender'];
        this.filteredStudents = this.dataFilter.filter(this.students, props, filterText);
    } else {
      this.filteredStudents = this.students;
    }
  }

  loadStudents() {
    this.studentService.getStudents(this.pagination.currentPage, this.pagination.itemsPerPage, this.studentParams)
      .subscribe((res: PaginatedResult<Student[]>) => {
        this.students = this.filteredStudents = res.result;
        this.pagination = res.pagination;
    }, error => {
      this.alertify.error(error);
    });
  }

  addNewStudent(studentID: number) {
    this.router.navigate(['/student/edit/' + studentID]);
  }

}

