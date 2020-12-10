import { NgModule } from "@angular/core";

import { CommonModule } from "@angular/common";
import { RouterModule } from "@angular/router";

import { MaterialModule } from "../material.module";
import { LoadingDialogComponent } from './comoponents/loading/loading-dialog/loading-dialog.component';
import { ErrorDialogComponent } from './comoponents/error-dialog/error-dialog.component';
import { LoadingDialogService } from './comoponents/loading/loading-dialog.service';
import { ErrorDialogService } from './comoponents/error-dialog/error-dialog.service';


const sharedComponents = [LoadingDialogComponent, ErrorDialogComponent];

@NgModule({
  declarations: [...sharedComponents],
  imports: [CommonModule, RouterModule, MaterialModule],
  exports: [...sharedComponents],
  providers: [ErrorDialogService, LoadingDialogService],
  entryComponents: [...sharedComponents]
})
export class SharedModule {}
