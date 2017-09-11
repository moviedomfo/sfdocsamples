import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import { PersonsService }  from './../service/persons.service';
import {PersonBE} from '../../app/model/persons.model'
@Component({
  template: `
    <h2>Listaodo de gente </h2>
    <ul class="items">
        [class.selected]="persona.IdPersona === selectedId">
        <a [routerLink]="['/persona', persona.IdPersona]">
          <span class="badge">{{ persona.IdPersona }}</span>{{ persona.Nombre }}
        </a>
      </li>
    </ul>

    <button routerLink="/sidekicks">Go to sidekicks</button>
  `
})
// @Component({
//   selector: 'app-persons',
//   templateUrl: './persons.component.html',
//   styleUrls: ['./persons.component.css']
// })
export class PersonsComponent implements OnInit {
  private selectedId: number;
  personas$: Observable<PersonBE[]>;
  constructor( private service: PersonsService,   private route: ActivatedRoute) { }

  ngOnInit() {
    this.personas$ = this.route.paramMap
    .switchMap((params: ParamMap) => {
      // (+) before `params.get()` turns the string into a number
      this.selectedId = +params.get('id');
      return this.service.getPersonas();
    });
  }

}
