import { Injectable } from '@angular/core';
import { IMovimiento, Movimiento } from '../model/movimientos.model';
//permmite cambiar la variable obsevada
import { Subject } from 'rxjs/Subject';
//permite observar
import { Observable } from 'rxjs/Observable';

@Injectable()
export class ClienteService {
  private movimientoList: IMovimiento[] = [];
  private movimientoList$: Subject<IMovimiento[]> = new Subject<IMovimiento[]>();
  private m: Movimiento;
  private cars: any[] = [
    'Ford', 'Chevrolet', 'Buick'
  ];

  constructor() {
    this.m = new Movimiento();


  }



  createMovimiento(movimiento: Movimiento) {

    //Clona movimiento por parametro
    var movClone: IMovimiento = Object.assign({}, movimiento);
    this.movimientoList.push(movClone);
    //esto es lo siguiente q envio o notifico. lo que le envio es algo q coincida con la declaracion
    //Subject<IMovimiento[]>
    //Emito un evento.
    this.movimientoList$.next(this.movimientoList);
    // mov.id=0;
    // mov.fecha= new Date(Date.now());
    // mov.tipoId=11;
    // mov.importe=1000;

    // let mov2 :Movimiento =  {  
    //   id=0,
    //   fecha= new Date(Date.now()),
    //   tipoId=11,
    //   importe=1000};


  }

  getMovimientoList$(): Observable<Movimiento[]> {

    return this.movimientoList$.asObservable();
  }

  getMovimiento(movId: number): IMovimiento {
    let mov: IMovimiento;
    mov = this.movimientoList.filter(p => p.id === movId)[0];
    return mov;
  }
  myData() {
    return 'This is my data, man!';
  }

}
