import { NgModule }             from '@angular/core';
import { ModuleWithProviders } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {provideRoutes} from  '@angular/router';
import { AppComponent } from './app.component';
import { ClientesComponent } from './clientes/clientes.component';
import { SelectivePreloadingStrategy }   from './selective-preloading-strategy'
import { CanDeactivateGuard }       from './can-deactivate-guard.service';
export const appRoutes: Routes = [
    {path:'', redirectTo:'clientes', pathMatch:'full'},
    {path:'clientes',component :ClientesComponent}
];


@NgModule({
  imports: [
    RouterModule.forRoot(
      appRoutes,
      { preloadingStrategy: SelectivePreloadingStrategy }
    )
  ],
  exports: [
    RouterModule
  ],
  providers: [
    CanDeactivateGuard,
    SelectivePreloadingStrategy
  ]
})

//export const routes : ModuleWithProviders = RouterModule.forRoot(appRoutes);


export class AppRoutingModule {}