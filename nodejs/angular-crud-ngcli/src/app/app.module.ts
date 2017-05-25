import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { AlertModule } from 'ngx-bootstrap';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { AppComponent } from './app.component';
import { ClienteComponent } from './cliente/cliente.component';
import { FontAgComponent } from './font-ag/font-ag.component';
import { ModelDialogComponent } from './model-dialog/model-dialog.component';
import { BootstrapModalModule } from 'ng2-bootstrap-modal';
@NgModule({
  declarations: [
    AppComponent,
    ClienteComponent,
    FontAgComponent,
    ModelDialogComponent
  ],
  imports: [
    AlertModule.forRoot(),
    BsDropdownModule.forRoot(),
    BrowserModule,BootstrapModalModule,
    FormsModule,
    HttpModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
