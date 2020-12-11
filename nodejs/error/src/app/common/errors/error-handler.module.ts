import { NgModule, ErrorHandler } from "@angular/core";
import { CommonModule } from "@angular/common";
import { GlobalErrorHandler } from "./global-error-handler";
import { HttpInterceptorService } from "../HttpInterceptorService";
import { HTTP_INTERCEPTORS } from "@angular/common/http";

@NgModule({
  declarations: [],
  imports: [CommonModule],
  providers: [
    { provide: ErrorHandler, useClass: GlobalErrorHandler },

  ]
})
export class ErrorHandlerModule {}
