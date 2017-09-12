import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import { PersonsService }  from './../service/persons.service';
import {PersonBE} from '../../app/model/persons.model'

@Component({
  selector: 'app-persons',
  templateUrl: './persons.component.html',
  styleUrls: ['./persons.component.css']
})
export class PersonsComponent implements OnInit {
  private selectedId: number;
  personId :number;
  personas$: Observable<PersonBE[]>;
  constructor( 
    private service: PersonsService,   
    private route: ActivatedRoute) 
  { }


  ngOnInit() {
    // console.log("-------------------------------------");
    // // console.log(JSON.stringify( this.route.url));
    // console.log(this.route);
    // this.personId= this.route.snapshot.params['id'];
    // alert(this.personId);
    // console.log("-------------------------------------");
    this.personas$ = this.route.paramMap
    .switchMap((params: ParamMap) => {
      // (+) before `params.get()` turns the string into a number
      this.selectedId = +params.get('id');
      return this.service.getPersons();
    });
  }

}
