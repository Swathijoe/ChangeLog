import { Component, OnInit } from '@angular/core';  
import { SocialAuthService } from "angularx-social-login";
import { FacebookLoginProvider, GoogleLoginProvider } from "angularx-social-login";
// import { Socialusers } from '../models' ; 
import { LoginService } from '../services';  
import { Router, ActivatedRoute, Params } from '@angular/router';  
import { LoginUser, Socialusers } from '../models';
@Component({  
  selector: 'app-login',  
  templateUrl: './login.component.html',  
  styleUrls: ['./login.component.scss']  
})  
export class LoginComponent implements OnInit {  
  response?:any;  
  socialusers?:Socialusers;
  user?:LoginUser ={
    id: '',
    name :'',
    socialLoginId:'',
    email:'',
    socialLoginToken:'',
    password:'',
  }

  constructor(  
    public OAuth: SocialAuthService,  
    private LoginService: LoginService,  
    private router: Router  
  ) { }  

  ngOnInit() {  
  }  
  public socialSignIn(socialProvider: string) {  
    let socialPlatformProvider;  
    if (socialProvider === 'google') {  
      socialPlatformProvider = GoogleLoginProvider.PROVIDER_ID;  
    }  

    if (socialPlatformProvider){
      this.OAuth.signIn(socialPlatformProvider).then((socialusers:any) => {         
        this.ValidateUser(socialusers);  
      });  
    }
  }  

  public login()
  {
    console.log(this.user);
    this.ValidateUser(this.user);
  }

  
  ValidateUser(user:any) {
    this.LoginService.authendicateUser(user).subscribe((res: any) => {      
      if(res.token != undefined)     
      {        
        this.response = res.token;  
        localStorage.setItem('authToken', this.response);         
        this.router.navigate([`/log-list`]);  
      }
      else
      {
        alert(res);
      }  
    })  
  }  
}  
