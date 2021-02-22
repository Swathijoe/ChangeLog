import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LogListComponent } from '../log-list/log-list.component';
import { ChangeLogType, LogList } from '../models';
import { ChangeLogService } from '../services/changeLog.service';


@Component({
  selector: 'app-log-detail',
  templateUrl: './log-detail.component.html',
  styleUrls: ['./log-detail.component.scss']
})
export class LogDetailComponent implements OnInit {
  model: LogList =new LogList();
  changeLogTypes: ChangeLogType[] = [ChangeLogType.NewRelease, ChangeLogType.Update, ChangeLogType.Fix];

  constructor(private changeLogService: ChangeLogService, private router: Router) { }

  ngOnInit() {
   
  }

  onSubmit() {
    this.changeLogService.addRelease(this.model).subscribe(() => {      
      this.router.navigate(['/log-list']);
    });
  }

  onCancel() {
    this.router.navigate(['/log-list']);
  }

}
