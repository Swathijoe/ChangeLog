import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SocialAuthService } from 'angularx-social-login';

import { LogList } from '../models';
import { LoginService } from '../services';
import { ChangeLogService } from '../services/changeLog.service';


@Component({
  selector: 'app-log-list',
  templateUrl: './log-list.component.html',
  styleUrls: ['./log-list.component.scss']
})
export class LogListComponent implements OnInit {
  ChangeLogList?: LogList[];
  recordsAvailable : boolean = false;

  constructor(private changeLogService: ChangeLogService, 
    private router: Router,
    private loginService:LoginService,
    public OAuth: SocialAuthService,  ) { }

  ngOnInit() {   
    this.getList();
  }

  addRelease() {
    this.router.navigate(['/log/0']);
  }

  deleteRelease(id: any) {
    if (confirm('Are you sure to delete this release ?') == true) {
      this.changeLogService.delete(id)
      .subscribe(() => {        
        this.getList();
      });
    }
  }

  getList(){
    this.changeLogService.getChangeLogs().then((res:any) => {
      if(res.length > 0){
        this.recordsAvailable = true;
      }
      else
      this.recordsAvailable = false;
      this.ChangeLogList = res;
      this.ChangeLogList.sort((a,b)=> a.changeLogTime < b.changeLogTime ? 1 : -1);
    });
  }
  public logout()
  {
    this.OAuth.signOut();
    this.loginService.LogOut();
  }
}
