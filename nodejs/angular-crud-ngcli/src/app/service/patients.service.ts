import { Injectable } from '@angular/core';
import { IPatient, PatientBE } from '../model/patients.model';
import { Param, IParam, IContextInformation } from '../model/common.model';
import { HealtConstants, contextInfo } from "../model/common.constants";
import { Http, Response, RequestOptions, Headers } from '@angular/http';
import { PersonsBE } from '../model/persons.model';
//permmite cambiar la variable obsevada
import { Subject } from 'rxjs/Subject';
//permite observar
import { Observable } from 'rxjs/Observable';

@Injectable()
export class PatientsService {

  private static _token: any;

  private patientList: PatientBE[] = [];
  private patientList$: Subject<IPatient[]> = new Subject<IPatient[]>();

  public paramList: Param[];
  private patient: PatientBE;
  private contextInfo: IContextInformation;
  constructor(private http: Http) {
    this.contextInfo = contextInfo;
  }




  reriveAllPatientList$(): Observable<PatientBE[]> {
    return this.patientList$.asObservable();
  }


  retrivePatientsSimple$(): Observable<PatientBE[]> {


    //map retorna el mapeo de un json que viene del servicio que tiene la misma estructura que  PatientBE
    return this.http.post(`${HealtConstants.HealthAPI_URL}patients/RetrivePatientsSimple`, HealtConstants.httpOptions)
       .map(function (res: Response) {
         return res.json();
       }).catch(this.handleErrorObservable);
  }



  //RetrivePatientsService
  reriveAllPatientList2$(): Observable<PatientBE[]> {

    let bussinesData: any = {
      Nombre: "",
      Apellido: "",
      NroDocumento: "",
      Id: "",
      ReturnGrid: ""

    }
    var requetObj = {
      SecurityProviderName: null,
      ServiceName: 'RetrivePatientsService',
      BusinessData: bussinesData,
      ContextInformation: this.contextInfo
    };
    var paramsSimple = {
      apellido: "Ovieso ", nombre: "Marcelo"

    };
    let data = new URLSearchParams();
    data.append('nombre', "marsadasd");
    data.append('apellido', "asdasdasdas");

   
    // this.http.post(`${HealtConstants.HealthAPI_URL}patients/retrivePatients`, data,HealtConstants.httpOptions).subscribe(res => res.json
    // );
    //map retorna el mapeo de un json que viene del servicio que tiene la misma estructura que  PatientBE
    return this.http.post(`${HealtConstants.HealthAPI_URL}patients/retrivePatients`, HealtConstants.httpOptions)
      .map(function (res: Response) {

        return res.json();
      }).catch(this.handleErrorObservable);
  }


    createPatients(patient: PatientBE) {

    //Clona Patients por parametro
    var patientClone: IPatient = Object.assign({}, patient);
    this.patientList.push(patientClone);
    //esto es lo siguiente q envio o notifico. lo que le envio es algo q coincida con la declaracion
    //Subject<IPatients[]>
    //Emito un evento.
    this.patientList$.next(this.patientList);


  }

  private handleErrorObservable(error: Response | any) {
    console.error(error.message || error);
    return Observable.throw(error.message || error);
  }
  private handleErrorPromise(error: Response | any) {
    console.error(error.message || error);
    return Promise.reject(error.message || error);
  }


  getPatientById(patintId: number): IPatient {
    let patient: IPatient;
    patient = this.patientList.filter(p => p.PatientId === patintId)[0];
    return patient;
  }


}
