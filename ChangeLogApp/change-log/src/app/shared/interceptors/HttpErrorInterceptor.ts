import {
    HttpEvent,
    HttpInterceptor,
    HttpHandler,
    HttpRequest,
    HttpResponse,
    HttpErrorResponse
   } from '@angular/common/http';
   import { Observable, throwError } from 'rxjs';
   import { retry, catchError } from 'rxjs/operators';
   
   export class HttpErrorInterceptor implements HttpInterceptor {
    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
      return next.handle(request)
        .pipe(
          retry(1),
          catchError((error: HttpErrorResponse) => {
            console.log(error);
            let errorMessage = '';

            if(error.status === 401)
            {
                errorMessage ="Unauthorized."
            }
            else if (error.error instanceof ErrorEvent) {
              // client-side error              
              errorMessage = `Error: ${error.error}`;
            } else {
              // server-side error
              errorMessage = `Login failed.`;
            }
            window.alert(errorMessage);
            return throwError(errorMessage);
          })
        )
    }
   }