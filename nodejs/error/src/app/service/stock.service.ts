import { Injectable, Inject } from '@angular/core';

// permmite cambiar la variable obsevada
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { HttpClient,  HttpParams } from '@angular/common/http';
import { StockBE } from '../model/stock.model';
import { AppConstants } from '../model/common.constants';
import { CommonService } from './common.service';


@Injectable()
export class stockService {


  
  //public currentstockChange_subject$: Subject<ProviderBE> = new Subject<ProviderBE>();

  constructor(private commonService: CommonService, private http: HttpClient) {

  }




  retriveStock$(searchText: string, stockType?: number):  Observable<StockBE[]> {

    if (!searchText)
      searchText = '';
    
    let stockTypeTxt = '';
    if(stockType)
        stockTypeTxt= stockType.toString();
    
    const httpParams = new HttpParams()
      .set(`searchText`, searchText)
      .set(`stockType`, stockTypeTxt);

      return this.http.get<StockBE[]>(`${AppConstants.AppAPI_URL}stock/retriveAll`, { params: httpParams }).pipe(
        map(res => {
  
          return res;
        }));
        

    //let outhHeader = this.commonService.get_AuthorizedHeader();

    // return this.http.get<StockBE[]>(`${AppConstants.AppAPI_URL}stock/retriveAll`, { headers: outhHeader, params: httpParams }).pipe(
    //   map(res => {

    //     return res;
    //   }));
    //   })).pipe(catchError(handleError));


  }
  retriveStock2$(searchText: string, stockType?: number):  Observable<StockBE[]> {

    if (!searchText)
      searchText = '';
    
    let stockTypeTxt = '';
    if(stockType)
        stockTypeTxt= stockType.toString();
    
    const httpParams = new HttpParams()
      .set(`searchText`, searchText)
      .set(`stockType`, stockTypeTxt);

   
    let outhHeader = this.commonService.get_AuthorizedHeader();

     return this.http.get<StockBE[]>(`${AppConstants.AppAPI_URL}stock/retriveAll`, { headers: outhHeader, params: httpParams }).pipe(
       map(res => {

         return res;
       }));
    //   })).pipe(catchError(handleError));


  }

  // private handleError(httpError:HttpErrorResponse){

  //     if(httpError.error instanceof ErrorEvent){
  //       alert('Client side error: ' + httpError.error.message) ;
  //       return;
  //     }

  //     //server error
  //     return new ErrorObservable("")


  // }


  
  

}
