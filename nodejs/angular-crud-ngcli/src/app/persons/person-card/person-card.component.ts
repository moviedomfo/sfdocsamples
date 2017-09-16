import { Component, OnInit } from '@angular/core';
import { Subject } from 'rxjs/Subject';
import { Observable } from 'rxjs/Observable';
import { PatientsService ,CommonService} from '../../service/index';
import { PersonBE,IContextInformation, IParam, Param ,CommonValuesEnum,TipoParametroEnum} from '../../model/index';
import { FormGroup } from '@angular/forms';
import {ViewChild, ElementRef,Renderer2,AfterContentInit } from '@angular/core';

@Component({
  selector: 'app-person-card',
  templateUrl: './person-card.component.html',
  styleUrls: ['./person-card.component.css']
})
export class PersonCardComponent implements AfterContentInit  {
  private select_form: FormGroup;
  private currenPerson:PersonBE;
  private selectedPais:Param;
  private selectedEstadoCivil:number;
  private selectedTipoDoc:Param;
  paises$: Observable<Param[]>;
  paises:Param[];
  estadoCivilList$: Observable<Param[]>;
  estadoCivilList:Param[];
  tipoDocumentoList$: Observable<Param[]>;
  tipoDocumentoList:Param[];
  @ViewChild('cmbEstadoCivil') cmbEstadoCivil: ElementRef;

  constructor(
      private patientService: PatientsService,
      private commonService: CommonService,
      private rd: Renderer2) {
      
  }
  ngAfterContentInit(){
  
  //   var comboEstadocivil=  (<HTMLInputElement>document.getElementById('cmbEstadoCivil'));
   
  //  console.log(this.cmbEstadoCivil);
   // console.log(this.comboEstadocivil.nativeElement);

    //comboEstadocivil.value = '602';
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
        var p:Param=new Param();
        p.Descripcion=  "Seleccione una opcion";
        p.Nombre=  "Seleccione una opcion";
        p.IdParametro= CommonValuesEnum.SeleccioneUnaOpcion;
        
        this.estadoCivilList.push(p);
        
        this.currenPerson.IdEstadoCivil=CommonValuesEnum.SeleccioneUnaOpcion;
       
      }
    );
    this.tipoDocumentoList$ = this.commonService.searchParametroByParams$(TipoParametroEnum.TipoDocumento,null);
    this.tipoDocumentoList$.subscribe(
      res => {
       
        this.tipoDocumentoList = res;

      }
    );
    this.setActive(602);
    
    
  }
  
  setActive(active_value: number){
    //this.select_form.get('cmbEstadoCivil').patchValue(active_value);
    // this.select_form.get('cmbEstadoCivil').get('#' + active_value)
    // .setValue('select',true);
  
 }


  onPaisSelection(event) {        alert(this.selectedPais);      }
  onEstadoCivilSelection(event) {       
    console.log(event);
    console.log(this.selectedEstadoCivil);
     
     }
      
}
