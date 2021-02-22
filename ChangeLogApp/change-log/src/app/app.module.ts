import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { SocialLoginModule, SocialAuthServiceConfig } from 'angularx-social-login';
import {  GoogleLoginProvider,  FacebookLoginProvider} from 'angularx-social-login';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { LogListComponent } from './log-list/log-list.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { DashboardComponent } from './dashboard/dashboard.component';
import { ChangeLogService } from './services/changeLog.service';
import { Constants } from './shared/common/constants';
import { FormsModule } from '@angular/forms';
import { LogDetailComponent } from './log-detail/log-detail.component';
import { ReplaceSpacePipe } from './shared/common/Pipe';
import { HttpErrorInterceptor } from './shared/interceptors/HttpErrorInterceptor';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    LogListComponent,
    DashboardComponent,
    LogDetailComponent,
    ReplaceSpacePipe
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    SocialLoginModule,
    HttpClientModule    
  ],
  providers: [
    {
      provide: 'SocialAuthServiceConfig',
      useValue: {
        autoLogin: false,
        providers: [
          {
            id: GoogleLoginProvider.PROVIDER_ID,
            provider: new GoogleLoginProvider(
              '564378177789-7kqj8o3b32apvpsjqqk74lapef8gi6fi.apps.googleusercontent.com'
            )
          },
          {
            id: FacebookLoginProvider.PROVIDER_ID,
            provider: new FacebookLoginProvider('clientId')
          }
        ]
      } as SocialAuthServiceConfig,
    },
    ChangeLogService,
    Constants,
    { provide: HTTP_INTERCEPTORS, useClass: HttpErrorInterceptor, multi: true  }
  ],
  bootstrap: [AppComponent,LoginComponent]
})
export class AppModule { }
