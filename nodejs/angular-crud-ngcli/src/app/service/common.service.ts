import { Injectable } from '@angular/core';
import { HealtConstants, contextInfo } from "../model/common.constants";
import { Param, IParam, IContextInformation,ContextInformation ,Request, IRequest, IResponse, Result,ServiceError } from '../model/common.model';
import { Http, Response, RequestOptions, Headers,URLSearchParams } from '@angular/http';
//permmite cambiar la variable obsevada
import { Subject } from 'rxjs/Subject';
//permite observar
import { Observable } from 'rxjs/Observable';

@Injectable()
export class CommonService {
  public paramList: Param[]= [];
  public paramList$: Subject<Param[]> = new Subject<Param[]>();
  constructor(private http: Http) { }

  searchParametroByParams$(idTipoParametro :number,idParametroRef :number) : Observable<Param[]>
  {
    
    var bussinesData = {
      IdParametroRef : idParametroRef,
      IdTipoParametro :idTipoParametro,
      Vigente :true
    };

    let searchParams: URLSearchParams = this.generete_get_searchParams("SearchParametroByParamsService", bussinesData);
    HealtConstants.httpOptions.search = searchParams;

    return this.http.get(`${HealtConstants.HealthExecuteAPI_URL}`, HealtConstants.httpOptions)
      .map(function (res: Response) {

        let resToObject: Result;
        resToObject = JSON.parse(res.json());

        if (resToObject.Error) {
          alert("Se encontraron errores " + resToObject.Error.Message);
        }

        let patient: Param[] = resToObject.BusinessData as Param[];

        return patient;
      });
  }

  //Metodo directo sin observable
  getById(parentId: number): Param {
    let param: Param;
    param = this.paramList.filter(p => p.ParentId === parentId)[0];
    return param;
  }


  generete_get_searchParams(serviceName,bussinesData):URLSearchParams
  {
    let searchParams: URLSearchParams = new URLSearchParams();
    var req = this.createFwk_SOA_REQ(bussinesData);
    req.ServiceName= serviceName;
    searchParams.set("serviceProviderName","health");//defaul 
    searchParams.set("serviceName",serviceName);
    searchParams.set("jsonRequest",JSON.stringify(req));

    

    return searchParams;
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

  processException(Error:ServiceError)
  {

  }
}
