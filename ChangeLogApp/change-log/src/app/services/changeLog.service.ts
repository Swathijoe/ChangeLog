import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { LogList } from '../models';
import { Constants } from '../shared/common/constants';
import { LoginService } from './login.service';


@Injectable({
  providedIn: 'root'
})

export class ChangeLogService {
    url?:string;
      constructor(private http: HttpClient,private constants:Constants,private loginService:LoginService) { }
    
      async getChangeLogs(responce?:any)
      {
        this.url = `${this.constants.API_URL}changelog` ;//'https://localhost:44332/api/changelog';        
        return this.http.get<LogList>(this.url,responce).toPromise();
      }

      delete(id: any) {
        const httpOptions = {
          headers: new HttpHeaders({
            'Content-Type': 'application/json',
            'Access-Control-Allow-Credentials': 'true',
            'Access-Control-Allow-Methods': 'GET, POST, OPTIONS',
            'Access-Control-Allow-Headers': 'Origin, Content-Type, Accept',
            'Authorization': this.loginService.getAuthorizationToken()
          })
        };
        return this.http.delete<void>(`${this.constants.API_URL}changelog/${id}`, httpOptions);
      }

      addRelease(release: LogList): Observable<any> {
        release.changeLogTime = new Date();
        release.userId = this.loginService.getCurrentUserId();
        let body = JSON.stringify(release);
    
        const httpOptions = {
          headers: new HttpHeaders({
            'Content-Type': 'application/json',
            // 'Access-Control-Allow-Credentials': 'true',
            // 'Access-Control-Allow-Methods': 'GET, POST, OPTIONS',
            // 'Access-Control-Allow-Headers': 'Origin, Content-Type, Accept',
            'Access-Control-Allow-Origin': '*',           
            'Authorization': this.loginService.getAuthorizationToken()
          })
        };
    
        return this.http.post(`${this.constants.API_URL}changelog/add`, body, httpOptions);
      }
    }