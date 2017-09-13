import { Component, OnInit } from '@angular/core';
import { Subject } from 'rxjs/Subject';
import { Observable } from 'rxjs/Observable';
import { PatientsService ,CommonService} from '../../service/index';
import { PersonBE,IContextInformation, IParam, Param ,TipoParametroEnum} from '../../model/index';


@Component({
  selector: 'app-person-card',
  templateUrl: './person-card.component.html',
  styleUrls: ['./person-card.component.css']
})
export class PersonCardComponent implements OnInit {

  private currenPerson:PersonBE;
  private selectedPais:Param;
  private selectedEstadoCivil:Param;
  
  paises$: Observable<Param[]>;
  paises:Param[];
  estadoCivilList$: Observable<Param[]>;
  estadoCivilList:Param[];
  tipoDocumentoList$: Observable<Param[]>;
  tipoDocumentoList:Param[];

  constructor(
      private patientService: PatientsService,
      private commonService: CommonService,) {

  }
  ngOnInit() {
    this.currenPerson = new PersonBE(-1000,"");
    this.paises$ = this.commonService.searchParametroByParams$(TipoParametroEnum.Paises,null);
    this.paises$.subscribe(
      res => {
        this.paises = res;
      
      }
    );
    this.estadoCivilList$ = this.commonService.searchParametroByParams$(TipoParametroEnum.EstadoCivil,null);
    this.estadoCivilList$.subscribe(
      res => {
        this.estadoCivilList = res;
      }
    );
    this.tipoDocumentoList$ = this.commonService.searchParametroByParams$(TipoParametroEnum.TipoDocumento,null);
    this.tipoDocumentoList$.subscribe(
      res => {
        this.tipoDocumentoList = res;
      }
    );
    
  }



  onPaisSelection(event) {        alert(this.selectedPais);      }
  onEstadoCivilSelection(event) {       
    console.log(event);
    console.log(this.selectedEstadoCivil);
     
     }
      
}
