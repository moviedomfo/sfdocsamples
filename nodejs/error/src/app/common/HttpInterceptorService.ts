import {
  HttpHandler,
  HttpRequest,
  HttpEvent,
  HttpErrorResponse,
  HttpInterceptor,
  HttpHeaders
} from "@angular/common/http";
import { Observable, throwError } from "rxjs";
import { catchError, finalize } from "rxjs/operators";

import { Injectable } from "@angular/core";
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
    private authService:AuthService
  ) {}

  intercept( request: HttpRequest<any>,    next: HttpHandler  ): Observable<HttpEvent<any>> {

    this.loadingDialogService.openDialog();
    let req;
    if(request.body.includes( '/api/security/authenticate'))
    {
      req = request.clone(
        {
          setHeaders: {
            'Content-Type': 'application/json; charset=utf-8',
            Accept: 'application/json',
            'securityProviderName':AppConstants.oaut_securityProviderName,
            'Access-Control-Allow-Methods': '*',
            'Access-Control-Allow-Headers': 'Content-Type, Access-Control-Allow-Headers, Authorization, X-Requested-With',
            'Access-Control-Allow-Origin': '*'
          }
        });
    }
    //let headers = this.get_AuthorizedHeader();
   
  
    //if contains any call to our  API
    if(!req && request.url.includes(AppConstants.AppAPI_URL)) 
    {
      let currentLogin: CurrentLogin =  this.getCurrenLoging();
     
      //if the user is logged in
      if(currentLogin){
        //Firsh let´s set the headers Bearer and CORS
        req = request.clone(
         {
           setHeaders: {
             'Content-Type': 'application/json; charset=utf-8',
             Accept: 'application/json',
             Authorization: `Bearer ${currentLogin.oAuth.access_token}`,
             'securityProviderName':AppConstants.oaut_securityProviderName,
             'Access-Control-Allow-Methods': '*',
             'Access-Control-Allow-Headers': 'Content-Type, Access-Control-Allow-Headers, Authorization, X-Requested-With',
             'Access-Control-Allow-Origin': '*'
           }
         }
       )
     }else{
       
       this.loadingDialogService.hideDialog();
       //llamar al loging por que no existen datos de autenticación
       this.authService.logout('/login');
       
       
     }
    }
   
    

    return next.handle(req).pipe(
      catchError((error: HttpErrorResponse) => {

        //Bearer error="invalid_token", error_description="The token expired at '12/12/2020 14:55:34'"
        //error.error.
        alert(error.status);
        console.error("Error from error interceptor", error);
        
         //aqui trabajaremos el error Si es 401 y requiere refresh token o si requiere loging por q el refresh_token expiro
         //requiere refreshtoken

         //requiere loging this.authService.logout('/login'); 
        if(error.status === 401){
          this.authService.logout('/login');
          this.loadingDialogService.hideDialog();
        }
        
        this.errorDialogService.openDialog(error.message ?? JSON.stringify(error), error.status);

       

        return throwError(error);
      }),
      finalize(() => {
        this.loadingDialogService.hideDialog();
      })
    ) as Observable<HttpEvent<any>>;
  }

  
  //Retorna un HttpHeaders con CORS y 'Authorization': "Bearer + TOKEN"
   get_AuthorizedHeader(): HttpHeaders {
    let currentLogin: CurrentLogin =  this.getCurrenLoging();
    if(currentLogin){
        let headers = new HttpHeaders({ 'Authorization': "Bearer " + currentLogin.oAuth.access_token }).set('securityProviderName',AppConstants.oaut_securityProviderName);
        headers.append('Access-Control-Allow-Methods', '*');
        headers.append('Access-Control-Allow-Headers', 'Content-Type, Access-Control-Allow-Headers, Authorization, X-Requested-With');
        headers.append('Access-Control-Allow-Origin', '*');
        return headers;
    }

  
  }

  getCurrenLoging(): CurrentLogin {
    var currentLogin: CurrentLogin;
    let str = localStorage.getItem('currentLogin');
    if (str) {
      currentLogin = JSON.parse(str);
     
      return currentLogin;
      
    }
    return null;

  }
}
