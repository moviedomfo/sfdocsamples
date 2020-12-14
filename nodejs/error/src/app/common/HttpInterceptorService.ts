import {
  HttpHandler,
  HttpRequest,
  HttpEvent,
  HttpErrorResponse,
  HttpInterceptor,
  HttpHeaders,
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, finalize } from 'rxjs/operators';

import { Injectable } from '@angular/core';
import { LoadingDialogService } from './loading-dialog.service';
import { ErrorDialogService } from './error-dialog/error-dialog.service';
import { CurrentLogin } from '../model/securityIdentity.model';
import { AppConstants } from '../model/common.constants';
import { AuthService } from '../service/auth.service';
import { stringify } from '@angular/compiler/src/util';

@Injectable()
export class HttpInterceptorService implements HttpInterceptor {
  constructor(
    private errorDialogService: ErrorDialogService,
    private loadingDialogService: LoadingDialogService,
    private authService: AuthService
  ) {}

  intercept(
    request: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    this.loadingDialogService.openDialog();
    let req;

    const urlSec = `${AppConstants.AppAPI_URL}security/authenticate`;

    if (request.url.includes(urlSec)) {
      req = request.clone();
      // req = request.clone(
      //   {
      //     setHeaders: {
      //       'Content-Type': 'application/json; charset=utf-8',
      //       Accept: 'application/json',
      //       'Access-Control-Allow-Methods': '*',
      //       'Access-Control-Allow-Headers': 'Content-Type, Access-Control-Allow-Headers, Authorization, X-Requested-With',
      //       'Access-Control-Allow-Origin': '*'
      //     }
      //   });
    }
    //let headers = this.get_AuthorizedHeader();

    //if contains any call to our  API
    if (!req && request.url.includes(AppConstants.AppAPI_URL)) {
      let currentLogin: CurrentLogin = this.getCurrenLoging();

      //if the user is logged in
      if (currentLogin) {
        //Firsh let´s set the headers Bearer and CORS
        req = request.clone({
          setHeaders: {
            'Content-Type': 'application/json; charset=utf-8',
            Accept: 'application/json',
            Authorization: `Bearer ${currentLogin.oAuth.access_token}`,
            securityProviderName: AppConstants.oaut_securityProviderName,
            'Access-Control-Allow-Methods': '*',
            'Access-Control-Allow-Headers':
              'Content-Type, Access-Control-Allow-Headers, Authorization, X-Requested-With',
            'Access-Control-Allow-Origin': '*',
          },
        });
      } else {
        this.loadingDialogService.hideDialog();
        //llamar al loging por que no existen datos de autenticación
        this.authService.logout('/login');
      }
    }

    return next.handle(req).pipe(
      catchError((httpError: HttpErrorResponse) => {
        //console.error("Error from error interceptor", httpError);

        //aqui trabajaremos el error Si es 401 y requiere refresh token o si requiere loging por q el refresh_token expiro
        //requiere refreshtoken
        let message;

        
        // si factory error
        if (httpError.error && httpError.error.ErrorId) {
          
          message = httpError.error.ExceptionMessage ||
            httpError.error.exceptionMessage ||
            httpError.error.Message;

          if (httpError.error.InnerException) {
            message =
              message + '\r\n' + httpError.error.ExceptionMessage ||
              httpError.error.InnerException.exceptionMessage ||
              httpError.error.InnerException.Message;
          }
        } else {
          message = httpError.error  || httpError.message;
        }

        let showDialog:boolean= true;
        //Si error de autenticacion
        if (httpError.status === 401) {
          
          showDialog = false;
          //user not exist
          //if (httpError.error.ErrorId === '450') {
            //message = httpError.error.Message;
          //}

          //si refresh token caduca se envia a loging nuevamente
          if (httpError.error && httpError.error.ErrorId === '460') {
            this.authService.logout('/login');
            
          }
          //we call refresh API
          let datos = this.refreshToken();
          
        }
        if(showDialog){
          this.errorDialogService.openDialog(
            message ?? JSON.stringify(httpError),
            httpError.status
          );
        }
        

        return throwError(httpError);
      }),
      finalize(() => {
        this.loadingDialogService.hideDialog();
      })
    ) as Observable<HttpEvent<any>>;
  }

  async refreshToken(){
    let x=   await this.authService.oauthRefreshToken$("").then();
    return x;
  }
  //Retorna un HttpHeaders con CORS y 'Authorization': "Bearer + TOKEN"
  get_AuthorizedHeader(): HttpHeaders {
    let currentLogin: CurrentLogin = this.getCurrenLoging();
    if (currentLogin) {
      let headers = new HttpHeaders({
        Authorization: 'Bearer ' + currentLogin.oAuth.access_token,
      }).set('securityProviderName', AppConstants.oaut_securityProviderName);
      headers.append('Access-Control-Allow-Methods', '*');
      headers.append(
        'Access-Control-Allow-Headers',
        'Content-Type, Access-Control-Allow-Headers, Authorization, X-Requested-With'
      );
      headers.append('Access-Control-Allow-Origin', '*');
      return headers;
    }
  }

  getCurrenLoging(): CurrentLogin {
    var currentLogin: CurrentLogin;
    let str = localStorage.getItem('currentLoginDemo');
    if (str) {
      currentLogin = JSON.parse(str);

      return currentLogin;
    }
    return null;
  }
}
