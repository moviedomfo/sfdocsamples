import { Component, OnInit } from '@angular/core';
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

  constructor() { }

  ngOnInit() {
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
  

}
