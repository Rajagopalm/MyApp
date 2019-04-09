import { Component, OnInit, ViewChild } from '@angular/core';
import { Student } from '../../_models/student';
import { StudentService } from '../../_services/student.service';
import { AlertifyService } from '../../_services/alertify.service';
import { ActivatedRoute } from '@angular/router';
import { NgxGalleryOptions, NgxGalleryImage, NgxGalleryAnimation } from 'ngx-gallery';
import { TabsetComponent } from 'ngx-bootstrap';

@Component({
  selector: 'app-student-detail',
  templateUrl: './student-detail.component.html',
  styleUrls: ['./student-detail.component.css']
})
export class StudentDetailComponent implements OnInit {
  @ViewChild('studentTabs') studentTabs: TabsetComponent;
  student: Student;
  galleryOptions: NgxGalleryOptions[];
  galleryImages: NgxGalleryImage[];

  constructor(private studentService: StudentService, private alertify: AlertifyService,
    private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.student = data['student'];
    });

    this.route.queryParams.subscribe(params => {
      const selectedTab = params['tab'];
      this.studentTabs.tabs[selectedTab > 0 ? selectedTab : 0].active = true;
    });
  }

  selectTab(tabId: number) {
    this.studentTabs.tabs[tabId].active = true;
  }

}
