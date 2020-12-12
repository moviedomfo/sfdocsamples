import { Component } from '@angular/core';
// permmite cambiar la variable obsevada
import { Observable, Subject, throwError } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { AuthService } from './service/auth.service';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Error handling';
  
  isAuthenticated: boolean;
  
  constructor( private authService:AuthService) {}


  logout() {
    this.authService.logout('/');
    
  }


}
