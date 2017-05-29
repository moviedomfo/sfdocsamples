import { Injectable } from '@angular/core';

@Injectable()
export class ClienteService {

  constructor() { }
 cars = [
    'Ford','Chevrolet','Buick'
  ];


  myData() {
    return 'This is my data, man!';
  }

}
