
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { Routes, RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import {rutesModule} from './app.router';
import { ClientesComponent } from './clientes/clientes.component';
import { PageNotFoundComponent } from './not-found.component';

@NgModule({
 
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    rutesModule
    
      ],
       declarations: [
        AppComponent,
        ClientesComponent,
        PageNotFoundComponent
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
