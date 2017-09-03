import { Component, OnInit } from '@angular/core';
import { PatientBE } from '../../model/patients.model';
import { PatientsService } from '../../service/patients.service';
import { CommonService } from '../../service/common.service';

//permmite cambiar la variable obsevada
import { Subject } from 'rxjs/Subject';
//permite observar
import { Observable } from 'rxjs/Observable';
@Component({
  selector: 'app-patient-grid',
  templateUrl: './patient-grid.component.html',
  styleUrls: ['./patient-grid.component.css']
})
export class PatientGridComponent implements OnInit {

  private patientList$: Observable<PatientBE[]>;
  private patientList: PatientBE[];
  currenPatient: PatientBE;
  columnDefs;
  constructor(private commonService: CommonService, private patientsService: PatientsService) {

  }

  ngOnInit() {
    this.columnDefs = [
      { headerName: "Nombre", field: "Persona.Nombre" },
      { headerName: "Apellido", field: "Persona.Apellido" },
      { headerName: "Fecha alta", field: "FechaAlta" }
    ];
  }
  private txtQuery: string;
  private patientCount: number;
  onKey_Enter(value: string) {
    //this.txtQuery += value + ' | ';
    this.retrivePatients();
  }


  retrivePatients() {


    this.patientList$ = this.patientsService.retrivePatients$(this.txtQuery);
    this.patientList$.subscribe(
      res => {


        this.patientList = res;
        
        this.patientCount = this.patientList.length;

      }
    );

  }

  onGridReady(params) {
    params.api.sizeColumnsToFit();
  }
}
