
import { Injectable } from '@angular/core';
import { Param, IParam, ContextInformation ,Request} from '../model/common.model';
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


  createFwk_SOA_REQ(bussinesData:any):Request
  {
    let contextInfo: ContextInformation= new ContextInformation() ;
    let req :Request = new Request();
    
    contextInfo.Culture = "ES-AR";
    contextInfo.ProviderNameWithCultureInfo = "";
    contextInfo.HostName  =  'localhost';
    contextInfo.HostIp  =  '10.10.200.168';
    contextInfo.HostTime  =  new Date(),
    contextInfo.ServerName  =  'WebAPIDispatcherClienteWeb';
    contextInfo.ServerTime  =  new Date();
    contextInfo.UserName  =  'moviedo',
    contextInfo.UserId  =  '';
    contextInfo.AppId  =  'Healt';
    contextInfo.ProviderName = 'health';
    req.ContextInformation=contextInfo;
    req.BusinessData=bussinesData;
    req.Error =null;
    req.SecurityProviderName="";
    req.Encrypt=false;

    return req;
  }
}
