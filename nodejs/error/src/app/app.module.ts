import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthenticationService } from './service/authentication.service';
import { stockService } from './service/stock.service';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { MaterialModule } from "./material.module";
import { MAT_FORM_FIELD_DEFAULT_OPTIONS } from "@angular/material/form-field";
import { SharedModule } from './common/shared.module';
import { CoreModule } from './common/core.module';
import { CommonService } from './service/common.service';
import { MatNativeDateModule } from '@angular/material/core';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    FormsModule,
    AppRoutingModule,
    HttpClientModule,
    MaterialModule,
    MatNativeDateModule,
    ReactiveFormsModule,
    CoreModule,
    SharedModule
  ],
  providers: [  
    {
    provide: MAT_FORM_FIELD_DEFAULT_OPTIONS,
    useValue: { appearance: "fill" }
    },
    CommonService,
    stockService,AuthenticationService],
  bootstrap: [AppComponent]
})
export class AppModule { }
