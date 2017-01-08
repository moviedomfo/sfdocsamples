import { NgModule }             from '@angular/core';
//import { ModuleWithProviders } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './app.component';
import { ClientesComponent } from './clientes/clientes.component';
//import { SelectivePreloadingStrategy }   from './selective-preloading-strategy'
//import { CanDeactivateGuard }       from './can-deactivate-guard.service';
import { PageNotFoundComponent }       from './not-found.component';

export const appRoutes: Routes = [
    {path:'', redirectTo:'clientes', pathMatch:'full'},
    {path:'clientes',component :ClientesComponent},
    { path: '**', component: PageNotFoundComponent }
];


@NgModule({
  imports: [
    RouterModule.forRoot(
      appRoutes
      //{ preloadingStrategy: SelectivePreloadingStrategy }
    )
  ],
  exports: [
    RouterModule
  ],
  providers: [
    //CanDeactivateGuard,
    //SelectivePreloadingStrategy,
    PageNotFoundComponent

  ]
})

//export const rutes : ModuleWithProviders = RouterModule.forRoot(appRoutes);


export class AppRoutingModule {}