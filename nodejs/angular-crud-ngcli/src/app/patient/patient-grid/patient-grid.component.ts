import { Component, OnInit } from '@angular/core';
import { PatientBE } from '../../model/patients.model';
import { PatientsService } from '../../service/patients.service';
import { CommonService } from '../../service/common.service';


//permmite cambiar la variable obsevada
import { Subject } from 'rxjs/Subject';
//permite observar
import { Observable } from 'rxjs/Observable';

// rich grid and rich grid declarative
import {DateComponent} from "../../commonComponents/date.component";
import {HeaderComponent} from "../../commonComponents/header.component";
import {HeaderGroupComponent} from "../../commonComponents/header-group.component";
import {GridOptions} from "ag-grid/main";
@Component({
  selector: 'app-patient-grid',
  templateUrl: './patient-grid.component.html',
  styleUrls: ['../../commonComponents/rich-grid.css', '../../commonComponents/proficiency-renderer.css'],
})
export class PatientGridComponent implements OnInit {
  private txtQuery: string;
  private patientCount: number;
  private patientList$: Observable<PatientBE[]>;
  private patientList: PatientBE[];
  currenPatient: PatientBE;
  private columnDefs:any[];
  private gridOptions:GridOptions;

  constructor(private commonService: CommonService, private patientsService: PatientsService) {
    this.patientList = [];
  }

  ngOnInit() {
    // we pass an empty gridOptions in, so we can grab the api out
     this.gridOptions = <GridOptions>{};
     this.gridOptions.dateComponentFramework = DateComponent;
     this.gridOptions.defaultColDef = {
         headerComponentFramework : <{new():HeaderComponent}>HeaderComponent,
         headerComponentParams : {
             menuIcon: 'fa-bars'
         }
     }
     this.gridOptions.getContextMenuItems = this.getContextMenuItems.bind(this);
     this.gridOptions.floatingFilter = true;

     this.createColumnDefs();
  }
  private getContextMenuItems(): any {
    let result: any = [
        { // custom item
            name: 'Alert ',
            action: function () {
                window.alert('Alerting about ');
            },
            cssClasses: ['redFont', 'bold']
        }];
    return result;
}
private createColumnDefs() {
  this.columnDefs = [
    { headerName: "Nombre", field: "Persona.Nombre" ,width: 100,pinned: true},
    { headerName: "Apellido", field: "Persona.Apellido" ,width: 100,pinned: true},
    { headerName: "Fecha alta", field: "FechaAlta",width: 100,pinned: true }
  ];
}
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
