import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Constants } from '../shared/common/constants';
import { LoginUser } from '../models';
import { Router } from '@angular/router';
import * as jwt_decode from "jwt-decode";

const _auth_Header_Key: string = 'Authorization';
const _auth_Prefix: string = 'Bearer';
const _auth_Token_Key = 'authToken';
const _currentUser_Key = 'currentUser';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
url?:string;
  constructor(private http: HttpClient,private constants:Constants,private router: Router) { }

  authendicateUser(response?:any)
  {
    this.url = `${this.constants.API_URL}user/authenticate`;
    var loginUser:LoginUser =  new LoginUser();
    loginUser.name = response.name;
    loginUser.socialLoginId = response.socialLoginId;
    loginUser.email = response.email;
    loginUser.socialLoginToken=response.authToken; 
    loginUser.password = response.password;   
    return this.http.post(this.url,loginUser);
  }

  getAuthorizationToken = (): string => {
    let token: string = localStorage.getItem(_auth_Token_Key);
    if (token === null) {
      this.OnAuthenticationFailed();
      return '';
    }
    else {
      //return 'Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImFzd2luIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy91c2VyZGF0YSI6ImM2YmRlZDE0LTIzN2MtNDZjNy1jNzJmLTA4ZDhkNjYyNDQ3NCIsIm5iZiI6MTYxMzkxNzMwOCwiZXhwIjoxNjE0MDAzNzA4LCJpYXQiOjE2MTM5MTczMDh9.uWAZGaJYxGdjThuMMGCqrQ8ArQtWwUCEm3V1Du5gXdU';
      return `${_auth_Prefix} ${token}`;
      //return (_auth_Prefix + ' ' + token).toString();
    }
  }

  OnAuthenticationFailed() {
    setTimeout((router: Router) => {
      this.router.navigate(['/']);
    }, 500);
  }
  public LogOut()
  {
    localStorage.clear();
    this.router.navigate([`/`]);  
  }

  getCurrentUserId = ():string =>{
    let token: string = localStorage.getItem(_auth_Token_Key);
    var accessToken:any = jwt_decode.default(token);
    console.log(accessToken);
    return accessToken.userId;
  }
}