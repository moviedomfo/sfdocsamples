import { HttpClient, HttpParams } from '@angular/common/http';
import { Component } from '@angular/core';
import { AppConstants } from './model/common.constants';
import { stockService } from './service/stock.service';
import { CommonService } from './service/common.service';
import { StockBE } from './model/stock.model';

// permmite cambiar la variable obsevada
import { Observable, Subject, throwError } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { authService } from './service/auth.service';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Error handling';
  
  isAuthenticated: boolean;
  public stockList: StockBE[];
  constructor(private http: HttpClient,
    private stockService:stockService,
    private authService:authService) {}


  logout() {
    this.authService.logout('/');
    
  }





  localError() {
    throw Error("The app component has thrown an error!");
  }

  failingRequest() {
    this.http.get("https://httpstat.us/404?sleep=2000").toPromise();
  }

  successfulRequest() {
    this.http.get("https://httpstat.us/200?sleep=2000").toPromise();
  }

  retriveStock() {
    
    var stockList$ = this.stockService.retriveStock$('',null);
    stockList$.subscribe(
      res => {
        this.stockList = res;

     

      },
      err => {

       console.log(err);
      }
    );
      

  }

}
