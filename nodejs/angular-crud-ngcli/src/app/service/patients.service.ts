import { Injectable } from '@angular/core';
import { IPatient, PatientBE } from '../model/patients.model';
import {Http,Response} from '@angular/http';
import {  PersonsBE } from '../model/persons.model';
//permmite cambiar la variable obsevada
import { Subject } from 'rxjs/Subject';
//permite observar
import { Observable } from 'rxjs/Observable';

@Injectable()
export class PatientsService {
  private PatientsList: IPatient[] = [];
  private PatientsList$: Subject<IPatient[]> = new Subject<IPatient[]>();
  
  
  private cars: any[] = [
    'Ford', 'Chevrolet', 'Buick'
  ];

  constructor(private http : Http ) { } 



  createPatients(Patients: PatientBE) {

    //Clona Patients por parametro
    var movClone: IPatient = Object.assign({}, Patients);
    this.PatientsList.push(movClone);
    //esto es lo siguiente q envio o notifico. lo que le envio es algo q coincida con la declaracion
    //Subject<IPatients[]>
    //Emito un evento.
    this.PatientsList$.next(this.PatientsList);
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

  getPatientsList$(): Observable<PatientBE[]> {

    return this.PatientsList$.asObservable();
  }

  getPatients(movId: number): IPatient {
    let mov: IPatient;
    mov = this.PatientsList.filter(p => p.PatientId === movId)[0];
    return mov;
  }
  myData() {
    return 'This is my data, man!';
  }

}
