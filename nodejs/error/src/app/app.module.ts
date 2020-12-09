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
import { CoreModule } from './common/core.module';
import { CommonService } from './service/common.service';
import { MatNativeDateModule } from '@angular/material/core';
import { HomeComponent } from './pages/home/home.component';
import { GameComponent } from './pages/game/game.component';



@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    GameComponent
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
    stockService,authService],
  bootstrap: [AppComponent]
})
export class AppModule { }
