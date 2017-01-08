import { NgModule } from '@angular/core';
import { ModuleWithProviders } from '@angular/core';

import { Routes, RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { ClientesComponent } from './clientes/clientes.component';


export const appRoutes: Routes = [
    {path:'', redirectTo:'clientes', pathMatch:'full'},
    {path:'clientes',component :ClientesComponent}
    
];

export const rutesModule : ModuleWithProviders = RouterModule.forRoot(appRoutes);