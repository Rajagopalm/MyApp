
import { Component, OnInit, ViewChild, HostListener } from '@angular/core';
import { Student } from '../../_models/student';
import { City } from '../../_models/city';

import { Router, ActivatedRoute } from '@angular/router';
import { AlertifyService } from '../../_services/alertify.service';
import { NgForm } from '@angular/forms';
import { StudentService } from '../../_services/student.service';
import { AuthService } from '../../_services/auth.service';
import { CityService } from 'src/app/_services/city.service';
import { District } from 'src/app/_models/district';

@Component({
  selector: 'app-student-edit',
  templateUrl: './student-edit.component.html',
  styleUrls: ['./student-edit.component.css']
})

export class StudentEditComponent implements OnInit {
    @ViewChild('editForm') editForm: NgForm;
    //student: Student;
    cityList: City[];
    districtList: District[];
    photoUrl: string;
    errorMessage: string;
    deleteMessageEnabled: boolean;
    operationText = 'Insert';
    // tslint:disable-next-line:no-inferrable-types
    isValid: boolean = true;

    student: Student = {
      id: null,
      cfssn: '',
      firstName: '',
      lastName: '',
      fatherName: '',
      gender: '',
      dateOfBirth: '',
      bloodGroup: '',
      religion: '',
      caste: '',
      motherTongue: '',
      nationality: '',
      firstAdmissionYear: 0,
      emailId: '',
      currentAddress: '',
      currentCity: '',
      currentCityId: 0,
      currentDistrict: '',
      currentDistrictId: 0,
      pinCode: '',
      phoneWithStdCode: '',
      profilePicBinary: '',
      mobileNumber1: '',
      mobileNumber2: '',
      placeOfBirth: '',
      stateOfBirth: '',
      countryOfBirth: '',
      disability:  false,
      disabilityType: '',
      isAllSemSupport : false,
      prevCfssn : ''
    };


    @HostListener('window:beforeunload', ['$event'])
    unloadNotification($event: any) {
      if (this.editForm.dirty) {
        $event.returnValue = true;
      }
    }

    constructor(
      public studentService: StudentService,
      private router: Router,
      public cityService: CityService,
      private route: ActivatedRoute,
      private alertify: AlertifyService,
      private authService: AuthService) { }

    ngOnInit() {
      // this.route.data.subscribe(data => {
      //   this.student = data['student'];
      //   this.operationText = 'Update';
      // });
      // this.authService.currentPhotoUrl.subscribe(photoUrl => this.photoUrl = photoUrl);
      //      const studentID = this.route.snapshot.paramMap.get('id');
      let id = this.route.snapshot.params['id'];
      if (id !== '0') {
        this.operationText = 'Update';
        this.getStudent(id);
      }
      this.getDistricts();
      this.getCities();

    }

    getStudent(id: string) {
      this.studentService.getStudent(id)
        .subscribe((student: Student) => {
          this.student = student;
        },
        (err: any) => {
          this.alertify.error(err);
          console.log(err)});
    }

    getCities() {
       this.cityService.getCities().subscribe((cityList: City[]) => this.cityList = cityList);
    }

    getDistricts() {
      this.cityService.getDistricts().subscribe((districtList: District[]) => this.districtList = districtList);
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
          this.alertify.success('Profile Added successfully');
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
      this.errorMessage = 'Profile Deleted successfully';
      this.router.navigate(['/students']);
    }, error => {
      this.alertify.error(error);
    });
  }




  }
