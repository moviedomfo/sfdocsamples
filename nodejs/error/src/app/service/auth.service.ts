import { Injectable } from '@angular/core';

import { AppConstants } from "../model/common.constants";
import { map, catchError } from 'rxjs/operators';
import { BehaviorSubject, Observable, Subject, throwError } from 'rxjs';
import { HttpClient, HttpParams } from '@angular/common/http';

import jwt_decode from "jwt-decode";
import { AuthenticateResponse, CurrentLogin, logingChange, SecurityUser } from '../model/securityIdentity.model';
import { CommonService } from './common.service';
import { Router } from '@angular/router';


@Injectable()
export class AuthService {  
 
  public isAuthenticated = new BehaviorSubject<boolean>(false);

  public logingChange_subject$: Subject<logingChange> = new Subject<logingChange>();



  constructor(private commonService: CommonService,
     private http: HttpClient,private router: Router) {

  }


  get_logingChange$(): Observable<logingChange> {
    return this.logingChange_subject$.asObservable();
  }

 

  //modo de uso ->  async metodo(){ this.isAuthenticated = await this.authService.checkAuthenticated();}
  async  isAuth() {

    var currentUser: CurrentLogin = this.getCurrenLoging();
    
    const authenticated = currentUser ? true:false;
    this.isAuthenticated.next(authenticated);

    // if (currentUser)
    //   this.isAuthenticated.next(authenticated);
    // else
    //   this.isAuthenticated.next(false);

      return authenticated;
  }
 
  
  ///Este método de autenticacion usa jwk contra un rest asp api
  public oauthToken$(userName: string, password: string): Observable<any> {


    var bussinesData = {
      userName: userName,
      password: password,
      grant_type: 'password',
      client_id: AppConstants.oaut_client_id,
      securityProviderName: AppConstants.oaut_securityProviderName,
      client_secret: AppConstants.oaut_client_secret
    }

    return this.http.post<any>(AppConstants.AppOAuth_URL,
      bussinesData, AppConstants.httpClientOption_contenttype_json).pipe(
        map(res => {

          let currentLogin: CurrentLogin = new CurrentLogin();
          currentLogin.oAuth = new AuthenticateResponse();
          currentLogin.oAuth = res;
          //currentLogin.oAuth.refresh_token = res.refresh_token;
          let tokenInfo = jwt_decode(currentLogin.oAuth.access_token); // decode token


          currentLogin.currentUser = new SecurityUser();
          currentLogin.currentUser.UserId = res.userId;
          currentLogin.currentUser.UserName = userName;
     

          localStorage.setItem('currentLoginDemo', JSON.stringify(currentLogin));
         
          return currentLogin;
        }));

  }

  
  public  oauthRefreshToken$(): Observable<any> {

   
    let currentLogin: CurrentLogin = JSON.parse(localStorage.getItem('currentLoginDemo'));

      var bussinesData = {

        refresh_token: currentLogin.oAuth.refresh_token,
        grant_type: 'refresh_token',
        client_id: AppConstants.oaut_client_id,
        securityProviderName: AppConstants.oaut_securityProviderName,
        client_secret: AppConstants.oaut_client_secret
      }


      // return this.http.post<any>(AppConstants.AppOAuth_URL,
      //   bussinesData, AppConstants.httpClientOption_contenttype_json).pipe(
    return this.http.post<any>(AppConstants.AppOAuth_URL,bussinesData).pipe(
          map(res => {
  
            let currentLogin: CurrentLogin = new CurrentLogin();
            currentLogin.oAuth = new AuthenticateResponse();
            currentLogin.oAuth = res;

            let tokenInfo = jwt_decode(currentLogin.oAuth.access_token); // decode token
            currentLogin.currentUser = new SecurityUser();
            currentLogin.currentUser.UserId = res.userId;
            currentLogin.currentUser.UserName = currentLogin.currentUser.UserName;

            localStorage.setItem('currentLoginDemo', JSON.stringify(currentLogin));
  
         
          }));//.pipe(catchError(this.commonService.handleError));

  }



  signOut(): void {
    // clear token remove user from local storage to log user out

    this.logout();
    let lc: logingChange = new logingChange();
    lc.isLogued = false;
    lc.returnUrl = '';
    this.logingChange_subject$.next(lc);
  }

  async logout() {
    try {
      //await this.signOut();
      localStorage.removeItem('currentLoginDemo');
      this.isAuthenticated.next(false);
      this.router.navigate(['login']);
    } catch (err) {
      console.error("authService logout error " + err);
    }
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

  retriveStock2$():  Observable<any> {


    
    const httpParams = new HttpParams()
      .set(`searchText`, '')
      .set(`stockType`, '');

   
    let outhHeader = this.commonService.get_AuthorizedHeader();

     return this.http.get<any>(`${AppConstants.AppAPI_URL}stock/retriveAll`, { headers: outhHeader, params: httpParams }).pipe(
       map(res => {

         return res;
       }));
 


  }




  
}