import { Component, OnInit } from '@angular/core';
import { Subject } from 'rxjs/Subject';
import { Observable } from 'rxjs/Observable';
import { PatientsService, CommonService } from '../../service/index';
import { PersonBE, IContextInformation, IParam, Param, CommonValuesEnum, TipoParametroEnum, CommonParams, HealtConstants } from '../../model/index';
import { FormGroup } from '@angular/forms';
import { ViewChild, ElementRef, Renderer2, AfterContentInit } from '@angular/core';

@Component({
  selector: 'app-person-card',
  templateUrl: './person-card.component.html',
  styleUrls: ['./person-card.component.css']
})
export class PersonCardComponent implements AfterContentInit {
  private select_form: FormGroup;
  private currenPerson: PersonBE;
  private selectedPais: Param;
  private selectedEstadoCivil: number;
  private selectedTipoDoc: Param;
  paises$: Observable<Param[]>;
  paises: Param[];
  estadoCivilList$: Observable<Param[]>;
  estadoCivilList: Param[];
  tipoDocumentoList$: Observable<Param[]>;
  tipoDocumentoList: Param[];

  fullImagePath: string;

  @ViewChild('cmbEstadoCivil') cmbEstadoCivil: ElementRef;

  constructor(
    private patientService: PatientsService,
    private commonService: CommonService,
    private rd: Renderer2) {

  }
  ngAfterContentInit() {

    //   var comboEstadocivil=  (<HTMLInputElement>document.getElementById('cmbEstadoCivil'));

    //  console.log(this.cmbEstadoCivil);
    // console.log(this.comboEstadocivil.nativeElement);

    //comboEstadocivil.value = '602';
    this.currenPerson.Sexo = 0;
    this.currenPerson.NroDocumento="0";
    this.fullImagePath = HealtConstants.ImagesSrc_Man;
    console.log(this.currenPerson.Sexo);
  }
  ngOnInit() {


    this.fullImagePath = HealtConstants.ImagesSrc_Woman;

    this.currenPerson = new PersonBE(-1, "");
    this.currenPerson.Sexo == 1;
    this.paises$ = this.commonService.searchParametroByParams$(TipoParametroEnum.Paises, null);
    this.paises$.subscribe(
      res => {
        this.paises = res;
      }
    );
    this.estadoCivilList$ = this.commonService.searchParametroByParams$(TipoParametroEnum.EstadoCivil, null);
    this.estadoCivilList$.subscribe(
      res => {
        this.estadoCivilList = this.commonService.appendExtraParamsCombo(res, CommonParams.SeleccioneUnaOpcion.IdParametro);
        this.currenPerson.IdEstadoCivil = CommonValuesEnum.SeleccioneUnaOpcion;

      }
    );
    this.tipoDocumentoList$ = this.commonService.searchParametroByParams$(TipoParametroEnum.TipoDocumento, null);
    this.tipoDocumentoList$.subscribe(
      res => {

        this.tipoDocumentoList = res;

      }
    );
    //this.setActive(602);


  }

  setActive(active_value: number) {
    //this.select_form.get('cmbEstadoCivil').patchValue(active_value);
    // this.select_form.get('cmbEstadoCivil').get('#' + active_value)
    // .setValue('select',true);

  }


  onPaisSelection(event) { alert(this.selectedPais); }
  onEstadoCivilSelection(event) {
    console.log(event);
    console.log(this.selectedEstadoCivil);

  }

  txtBox_NroDocumento_onKeyEnter(value: string) {
    //this.txtQuery += value + ' | ';
    console.log(value);
  }


  onSexChanged(inChecked: boolean) {

    if (inChecked) {
      this.fullImagePath = HealtConstants.ImagesSrc_Man;
      this.currenPerson.Sexo = 0;
    }
    else {
      
      this.fullImagePath = HealtConstants.ImagesSrc_Woman;
      this.currenPerson.Sexo = 1;
    }
  }


}
