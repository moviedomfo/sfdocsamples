import { Component, OnInit } from '@angular/core';
import { Subject } from 'rxjs/Subject';
import { Observable } from 'rxjs/Observable';
import { PersonBE, IContextInformation, IParam, Param, CommonValuesEnum, TipoParametroEnum, CommonParams, HealtConstants } from '../model/index';

import { FormGroup } from '@angular/forms';
import { ViewChild, ElementRef, Renderer2, AfterContentInit } from '@angular/core';
interface Friend {
    id: number;
    name: string;
}
@Component({
  selector: 'app-prueba',
  templateUrl: './prueba.component.html',
  styleUrls: ['./prueba.component.css']
})


export class PruebaComponent implements OnInit {

  public Suma : number=0; 
  public friends: Friend[];
     public radioValue: Friend;
    public selectValue: Friend;
    public textareaValue: string;
    public textValue: string;
public Sexo:number;
public fullImagePath: string;
  constructor() { 

    
  }

  ngOnInit() {
    this.fullImagePath = './../' + HealtConstants.ImagesSrc_Man;
     this.friends = [
            {
                id: 1,
                name: "Sarah"
            },
            {
                id: 2,
                name: "Tricia"
            },
            {
                id: 3,
                name: "Kim"
            }
        ];

    }

    onSexChanged(inChecked: boolean) {
        
            if (inChecked) {
              this.fullImagePath = './../' +HealtConstants.ImagesSrc_Man;
              this.Sexo = 0;
            }
            else {
                
              this.fullImagePath = './../' + HealtConstants.ImagesSrc_Woman;
              this.Sexo = 1;
            }
          }
        

}
