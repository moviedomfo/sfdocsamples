import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { AlertModule } from 'ngx-bootstrap';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { AppComponent } from './app.component';
import { PatientComponent } from './patient/patient.component';
import { FontAgComponent } from './font-ag/font-ag.component';
import { ModalDialogComponent } from './modal-dialog/modal-dialog.component';
import { BootstrapModalModule } from 'ng2-bootstrap-modal';
import {PatientsService} from './service/patients.service';
import {CommonService} from './service/common.service';
import {MovimientosModule} from './movimientos/movimientos.module';
import { PersonsComponent } from './persons/persons.component' ;
import {  PatientBE } from './model/patients.model';
import {IContextInformation,  ContextInformation,IRequest,Request,IResponse,Result,ServiceError } from './model/common.model';
// import {MovimientosComponent} from './movimientos/movimientos.component' ;

@NgModule({
  declarations: [
    AppComponent,
    PatientComponent,
    FontAgComponent,
    ModalDialogComponent,
    PersonsComponent
  ],
  imports: [
    AlertModule.forRoot(),
    BsDropdownModule.forRoot(),
    BrowserModule,
    BootstrapModalModule,
    FormsModule,
    HttpModule,MovimientosModule
  ],entryComponents: [
    ModalDialogComponent
  ],
  providers: [PatientsService,CommonService],
  bootstrap: [AppComponent]
})
export class AppModule { }
