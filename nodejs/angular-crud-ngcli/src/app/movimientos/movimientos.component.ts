import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-movimientos',
  templateUrl: './movimientos.component.html',
  styleUrls: ['./movimientos.component.css']
})
export class MovimientosComponent implements OnInit {

tittle :string;
  constructor() { }

  ngOnInit() {
    this.tittle="Este es el componente Movimientos";
  }

}
