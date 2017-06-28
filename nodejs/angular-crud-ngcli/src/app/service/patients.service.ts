import { Injectable } from '@angular/core';
import { IPatient, PatientBE } from '../model/patients.model';
import { Http, Response } from '@angular/http';
import { PersonsBE } from '../model/persons.model';
//permmite cambiar la variable obsevada
import { Subject } from 'rxjs/Subject';
//permite observar
import { Observable } from 'rxjs/Observable';

@Injectable()
export class PatientsService {
  private PatientList: PatientBE[] = [];
  private PatientList$: Subject<IPatient[]> = new Subject<IPatient[]>();


  private patient: PatientBE;

  constructor(private http: Http) {

    this.PatientList = [
      {
        PatientId: 100,

        IdPersona: 1,
        Apellido: "Oviedo"
      },

      {
        PatientId: 110,
        IdPersona: 22,
        Apellido: "Hendryxo"
      },

    ];

  }



  createPatients(patient: PatientBE) {

    //Clona Patients por parametro
    var patientClone: IPatient = Object.assign({}, patient);
    this.PatientList.push(patientClone);
    //esto es lo siguiente q envio o notifico. lo que le envio es algo q coincida con la declaracion
    //Subject<IPatients[]>
    //Emito un evento.
    this.PatientList$.next(this.PatientList);
    // mov.id=0;
    // mov.fecha= new Date(Date.now());
    // mov.tipoId=11;
    // mov.importe=1000;

    // let mov2 :Patients =  {  
    //   id=0,
    //   fecha= new Date(Date.now()),
    //   tipoId=11,
    //   importe=1000};


  }
  getPatientsListHttp$(): Observable<PatientBE[]> {

    //map retorna el mapeo de un json que viene del servicio que tiene la misma estructura que  PatientBE
    return this.http.get('../api/patient').map(function (res: Response) {
      return res.json();
    });
  }

  getPatientsList$(): Observable<PatientBE[]> {

    return this.PatientList$.asObservable();
  }

  getPatients(movId: number): IPatient {
    let patient: IPatient;
    patient = this.PatientList.filter(p => p.PatientId === movId)[0];
    return patient;
  }
  myData() {
    return 'This is my data, man!';
  }

}
