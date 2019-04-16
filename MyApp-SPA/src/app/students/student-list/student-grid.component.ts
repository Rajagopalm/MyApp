import { Component, Input, OnInit, ChangeDetectionStrategy } from '@angular/core';

import { Student } from '../../_models/Student';
import { Sorter } from '../../_services/sorter';

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

  constructor(private sorter: Sorter) { }

  ngOnInit() {

  }

  sort(prop: string) {
      this.sorter.sort(this.students, prop);
  }

}
