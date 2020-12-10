import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PepeComponent } from './pepe/pepe.component';
import { HomeComponent } from './pages/home/home.component';


const routes: Routes = [
  {
    path: 'home',
    component: HomeComponent
  },
  {
    path: 'login',
    component: PepeComponent
  },
  {
    path: 'game',
    component: HomeComponent,
  },
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
