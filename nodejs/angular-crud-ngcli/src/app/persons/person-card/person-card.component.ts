import { Component, OnInit } from '@angular/core';
import { PatientsService } from '../../service/index';
import { PatientBE,IContextInformation, IParam, Param } from '../../model/index';

@Component({
  selector: 'app-person-card',
  templateUrl: './person-card.component.html',
  styleUrls: ['./person-card.component.css']
})
export class PersonCardComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

}
