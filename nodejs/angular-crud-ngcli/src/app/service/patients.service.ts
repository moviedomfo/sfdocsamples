import { Injectable } from '@angular/core';
import { IPatient, PatientBE, Param, IParam } from '../model/patients.model';
import { Http, Response } from '@angular/http';
import { PersonsBE } from '../model/persons.model';
//permmite cambiar la variable obsevada
import { Subject } from 'rxjs/Subject';
//permite observar
import { Observable } from 'rxjs/Observable';

@Injectable()
export class PatientsService {
  private patientList: PatientBE[] = [];
  private patientList$: Subject<IPatient[]> = new Subject<IPatient[]>();

  public paramList: Param[];
  private patient: PatientBE;

  constructor(private http: Http) {

    this.paramList = [
      { Id: 1, Name: "ss", ParentId: 123 },
      { Id: 1, Name: "ss", ParentId: 33 }
    ];
    this.patientList = [
      {
        PatientId: 100,
        IdPersona: 1,
        Apellido: "Oviedo",
        Nombre: "Marcelo",
        FechaAlta: new Date(),
        LastAccessTime: new Date(),
        LastAccessUserId: "",
        LastHealthInstId: '',

      },
      {
        PatientId: 110,
        IdPersona: 22,
        Apellido: "Hendryxo",
        Nombre: "Jimmy",
        FechaAlta: new Date(),
        LastAccessTime: new Date(),
        LastAccessUserId: "",
        LastHealthInstId: ''
      }

    ];

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
  getPatientsListHttp$(): Observable<PatientBE[]> {

    //map retorna el mapeo de un json que viene del servicio que tiene la misma estructura que  PatientBE
    return this.http.get('../data/patient').map(function (res: Response) {

      
      return res.json();
    });
  }

  reriveAllPatientList$(): Observable<PatientBE[]> {

    return this.patientList$.asObservable();
  }

  getPatientById(patintId: number): IPatient {
    let patient: IPatient;
    patient = this.patientList.filter(p => p.PatientId === patintId)[0];
    return patient;
  }
  

}
