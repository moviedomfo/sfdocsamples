import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MovimientosComponent } from './movimientos.component';

@NgModule({
  //Importacion de modulos que nececito
  imports: [
    CommonModule
  ],
  //declaracion de modulos que emos echo
  declarations: [MovimientosComponent],
  //Si neceito exportar algun modulo desarrollado por mi
  exports:[MovimientosComponent]
})
export class MovimientosModule { }
