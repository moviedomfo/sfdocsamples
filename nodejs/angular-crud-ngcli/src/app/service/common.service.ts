
import { Injectable } from '@angular/core';
import {  Param, IParam } from '../model/common.model';
import { Http, Response } from '@angular/http';
//permmite cambiar la variable obsevada
import { Subject } from 'rxjs/Subject';
//permite observar
import { Observable } from 'rxjs/Observable';

@Injectable()
export class CommonService {
  public paramList: Param[]= [];
  public paramList$: Subject<Param[]> = new Subject<Param[]>();
  constructor(private http: Http) { }

  retriveAllParam$(parentId :number) : Observable<Param[]>
  {
    //return this.paramList$.asObservable();
     return this.http.get('../data/patient').map(function (res: Response) {
      return res.json();
    });
  }

  //Metodo directo sin observable
  getById(parentId: number): Param {
    let param: Param;
    param = this.paramList.filter(p => p.ParentId === parentId)[0];
    return param;
  }
}
