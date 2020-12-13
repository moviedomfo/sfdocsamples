import { Injectable } from '@angular/core';
import {
  AppConstants,
  CommonParams,
  ParamTypeEnum,
} from '../model/common.constants';
import {
  IAPIRequest,
  ContextInformation,
  ExecuteReq,
  Request,
  ServiceError,
  IpInfo,
  ParamBE,
  UbicacionItemBE,
  localidadesResponse,
  ApiServerInfo,
} from '../model/common.model';

// permmite cambiar la variable obsevada
import { Observable, Subject, throwError } from 'rxjs';
import { map, catchError } from 'rxjs/operators';

import { Router } from '@angular/router';
import {
  HttpHeaders,
  HttpClient,
  HttpErrorResponse,
  HttpParams,
} from '@angular/common/http';
import { CurrentLogin, logingChange } from '../model/securityIdentity.model';

//var colors = require('colors/safe');
@Injectable()
export class CommonService {
  constructor(private http: HttpClient, private router: Router) {}

  public logingChange_subject$: Subject<logingChange> = new Subject<logingChange>();
  get_logingChange$(): Observable<logingChange> {
    return this.logingChange_subject$.asObservable();
  }

  signOut(): void {
    // clear token remove user from local storage to log user out

    localStorage.removeItem('currentLogin');
    let lcRes: logingChange = new logingChange();
    lcRes.isLogued = false;
    lcRes.returnUrl = '';
    this.logingChange_subject$.next(lcRes);
  }

  // retornra el objeto Request de un URLSearchParams: Este contiene las siguientes clases
  //  SecurityProviderName?: string;
  // Encrypt?: boolean;
  // Error?:object;
  // ServiceName?: string;
  // BusinessData?:object;
  // CacheSettings?:object;
  // ContextInformation:ContextInformation;
  retrive_Request(searchParams: URLSearchParams) {
    let REQ: Request = JSON.parse(searchParams.get('jsonRequest')) as Request;

    return REQ;
  }

  //Retorna un HttpHeaders con CORS y 'Authorization': "Bearer + TOKEN"
  public get_AuthorizedHeader(): HttpHeaders {
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

  public get_AuthorizedHeader$(): Observable<HttpHeaders> {
    const obs = Observable.create(() => {
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
      } else {
        let er: ServiceError = new ServiceError();
        er.Message =
          'Not user authenticattion, the user needs to supply credentials';
        er.Status = 401;
        return throwError(er);
      }
    });

    return obs;
  }

  public getCurrenLoging(): CurrentLogin {
    var currentLogin: CurrentLogin;
    let str = localStorage.getItem('currentLoginDemo');
    if (str) {
      currentLogin = JSON.parse(str);
      return currentLogin;
    }
    return null;
  }
  ///Error inspection, interpretation, and resolution is something you want to do in the service, not in the component.
  public handleError(httpError: HttpErrorResponse | any) {
    console.log(httpError);
    let ex: ServiceError = new ServiceError();
    ex.Machine = 'PC-Desarrollo';
    // A client-side or network error occurred. Handle it accordingly.
    if (httpError.error instanceof ProgressEvent) {
      ex.Message = 'Client-side error occurred : ' + ex.Message;

      if (ex.Message.includes('api/oauth/authenticate')) {
        ex.Message = ex.Message + ' Can not authenticate ';
      }
      if (httpError.status == 0) {
        ex.Message =
          ex.Message +
          ' No es posible autenticar. Por favor comuníquese con el administrador';
      }
      ex.Message = ex.Message + '\r\n' + httpError.message;
      ex.Status = httpError.status;
      return throwError(ex);
    }

    // The backend returned an unsuccessful response code.
    // The response body may contain clues as to what went wrong,
    if (httpError instanceof HttpErrorResponse) {
      //alert(error.error);

      ex.Status = httpError.status;
      if (ex.Status === 400) {
        if (httpError.error) {
          ex = CommonService.getServiceError(httpError);
        } else {
          ex.Message = httpError.statusText + ' ' + httpError.message;
        }

        return throwError(ex);
      }

      if (ex.Status === 401) {
        ex.Message =
          'No está autorizado para realizar esta acción. Intente iniciar sesion nuevamente, si el problema persiste, por favor comuníquese con el administrador';
        alert(ex.Message);
        this.signOut();

        return;
      }

      if (httpError.error) {
        ex = CommonService.getServiceError(httpError);
        return throwError(ex);
      }

      if (httpError.message) {
        ex.Message = ex.Message + '\r\n' + httpError.message;
      }
      return throwError(ex);
    }

    ex.Message = httpError.message;

    return throwError(ex);

    // return an observable with a user-facing error message
    //return Observable.throw(ex); // <= B // se comenta para la version 7
  }

  public static getServiceError(
    httpError: HttpErrorResponse | any
  ): ServiceError {
    let ex: ServiceError = new ServiceError();
    ex.Status = httpError.status;
    ex.Type =
      httpError.error.ExceptionType ||
      httpError.error.exceptionType ||
      httpError.error.ClassName;
    if (ex.Type) {
      ex.Message =
        httpError.error.ExceptionMessage ||
        httpError.error.exceptionMessage ||
        httpError.error.Message;
      if (httpError.error.InnerException) {
        ex.Message =
          ex.Message + '\r\n' + httpError.error.ExceptionMessage ||
          httpError.error.InnerException.exceptionMessage ||
          httpError.error.InnerException.Message;
      }
    } else {
      ex.Message = httpError.error;
    }

    return ex;
  }

  public handleErrorObservable(error: ServiceError) {
    console.error(error.Message || error);
    return Observable.throw(error.Message);
  }
  public handleErrorPromise(error: Response | any) {
    return Promise.reject(error.message || error);
  }

  public handleHttpError(error) {
    console.log(JSON.stringify(error));
    if (error.status == '401') {
      //Error de permisos
      this.router.navigate(['login']);
    } else {
      console.log('Oto error status : ' + error.status);
    }

    return Observable.throw(error._body);
  }
  //cuando se le pasa un byte[] retorna su base64 string
  public convert_byteArrayTobase64(arrayBuffer: ArrayBuffer): string {
    var base64String = btoa(
      String.fromCharCode.apply(null, new Uint8Array(arrayBuffer))
    );
    return base64String;
  }
}
