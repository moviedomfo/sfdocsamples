import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { authService } from './service/auth.service';
import { stockService } from './service/stock.service';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { MaterialModule } from "./material.module";
import { MAT_FORM_FIELD_DEFAULT_OPTIONS } from "@angular/material/form-field";
import { SharedModule } from './common/shared.module';
import { CommonService } from './service/common.service';
import { MatNativeDateModule } from '@angular/material/core';
import { HomeComponent } from './pages/home/home.component';

import { GameComponent } from './pages/game/game.component';
import { PepeComponent } from './pepe/pepe.component';
import { CommonModule } from '@angular/common';



@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    GameComponent,
    PepeComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserModule,
    BrowserAnimationsModule,
  
    //
    //FlexLayoutModule,
    AppRoutingModule,
    HttpClientModule,
    MaterialModule,
    MatNativeDateModule,

    SharedModule
  ],
  providers: [  
    {
    provide: MAT_FORM_FIELD_DEFAULT_OPTIONS,
    useValue: { appearance: "fill" }
    },
    CommonService,
    stockService,authService],
    bootstrap: [AppComponent]
    

})
export class AppModule { }
