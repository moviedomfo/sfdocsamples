import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { StockBE } from 'src/app/model/stock.model';
import { AuthService } from 'src/app/service/auth.service';
import { stockService } from 'src/app/service/stock.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  public stockList: StockBE[];
  title = 'Error handling';
  
  constructor(private http: HttpClient,
    private stockService:stockService,
    private authService:AuthService) {}

  ngOnInit(): void {
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
  retriveStock2() {
    
    var stockList$ = this.stockService.retriveStock2$('',null);
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
