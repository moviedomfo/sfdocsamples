import {
  HttpHandler,
  HttpRequest,
  HttpEvent,
  HttpErrorResponse,
  HttpInterceptor,
  HttpHeaders,
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, finalize, switchMap, tap } from 'rxjs/operators';

import { Injectable } from '@angular/core';
import { LoadingDialogService } from './loading-dialog.service';
import { ErrorDialogService } from './error-dialog/error-dialog.service';
import { CurrentLogin } from '../model/securityIdentity.model';
import { AppConstants } from '../model/common.constants';
import { AuthService } from '../service/auth.service';


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
      req = this.setAutHeader(request);
    
    }
    //let headers = this.get_AuthorizedHeader();

    //if contains any call to our  API
    if (!req && request.url.includes(AppConstants.AppAPI_URL)) {
      let currentLogin: CurrentLogin = this.getCurrenLoging();

      //if the user is logged in
      if (currentLogin) {
        req = this.setAutHeaderAuth(request,currentLogin);

      } else {
        this.loadingDialogService.hideDialog();
        //llamar al loging por que no existen datos de autenticación
        this.authService.logout();
      }
    }

    return next.handle(req).pipe(
      catchError((httpError: HttpErrorResponse) => {
        let showDialog:boolean= true;

        //aqui trabajaremos el error Si es 401 y requiere refresh token o si requiere loging por q el refresh_token expiro
        //requiere refreshtoken
        let message = this.getFromHttpErrorMessage(httpError);
      
     
        
        //Si error de autenticacion
        if (httpError.status === 401) {
          
          showDialog = false;
          this.refreshToken()
          .pipe(
             switchMap(() => {
               //No tenemos que setrear el header ya que el mismo servicio authService.oauthRefreshToken lo hace
                return next.handle(req);
             })
           
          );
          
          //si refresh token caduca se envia a loging nuevamente
          if (httpError.error && httpError.error.ErrorId === '460') {
            this.authService.logout();
            
          }
         
          
          
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


  refreshToken(){

    //tab doesn't consime the observable subscriber 
    // subscribe  does execute the observable, tab just obvserve the response
   return   this.authService.oauthRefreshToken$().pipe(
       tap(()=>{
          console.log("refreshToken ");
       })
     );
    
  }


  


  setAutHeader (request: HttpRequest<any> ) {
    

      return  request.clone({
          setHeaders: {
            'Content-Type': 'application/json; charset=utf-8',
            Accept: 'application/json',
            'Access-Control-Allow-Methods': '*',
            'Access-Control-Allow-Headers':
              'Content-Type, Access-Control-Allow-Headers, Authorization, X-Requested-With',
            'Access-Control-Allow-Origin': '*',
          },
        }); 
  }
    //Firsh let´s set the headers Bearer and CORS
  //Retorna un HttpHeaders con CORS y 'Authorization': "Bearer + TOKEN"
  setAutHeaderAuth (request: HttpRequest<any>,currentLogin: CurrentLogin ) {
    

    return  request.clone({
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

  getFromHttpErrorMessage(httpError :HttpErrorResponse){
    let message;
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

    return message;
  }
}
