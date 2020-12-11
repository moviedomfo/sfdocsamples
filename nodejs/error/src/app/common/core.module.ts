import { NgModule } from "@angular/core";

import { CommonModule } from "@angular/common";
import { RouterModule } from "@angular/router";

import { MaterialModule } from "../material.module";
import { ErrorDialogComponent } from './error-dialog/error-dialog.component';
import { LoadingDialogService } from './loading-dialog.service';
import { ErrorDialogService } from './error-dialog/error-dialog.service';
import { LoadingDialogComponent } from './loading-dialog/loading-dialog.component';


const sharedComponents = [LoadingDialogComponent, ErrorDialogComponent];

@NgModule({
  declarations: [...sharedComponents],
  imports: [CommonModule, RouterModule, MaterialModule],
  exports: [...sharedComponents],
  providers: [ErrorDialogService, LoadingDialogService],
  entryComponents: [...sharedComponents]
})
export class CoreModule {}
