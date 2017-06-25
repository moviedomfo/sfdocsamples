import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { AlertModule } from 'ngx-bootstrap';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { AppComponent } from './app.component';
import { ClienteComponent } from './cliente/cliente.component';
import { FontAgComponent } from './font-ag/font-ag.component';
import { ModalDialogComponent } from './modal-dialog/modal-dialog.component';
import { BootstrapModalModule } from 'ng2-bootstrap-modal';
import {ClienteService} from './service/cliente.service';

import {MovimientosModule} from './movimientos/movimientos.module';
import { PersonsComponent } from './persons/persons.component' ;
// import {MovimientosComponent} from './movimientos/movimientos.component' ;

@NgModule({
  declarations: [
    AppComponent,
    ClienteComponent,
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
  providers: [ClienteService],
  bootstrap: [AppComponent]
})
export class AppModule { }
