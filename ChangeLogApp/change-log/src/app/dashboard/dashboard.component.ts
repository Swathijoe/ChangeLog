import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SocialAuthService } from 'angularx-social-login';
import { Socialusers } from '../models';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {

  //socialusers = new Socialusers();  
  constructor(public OAuth: SocialAuthService,    private router: Router) { }  

  ngOnInit() {  
   // this.socialusers = JSON.parse(localStorage.getItem('socialusers'));  
    //console.log(this.socialusers.image);  
  }  
  logout() {  
   alert(1);  
    this.OAuth.signOut().then(data => {  
      debugger;  
      this.router.navigate([`/Login`]);  
    });  
  }  
}
