//import { CanDeactivateComponent } from './app/can-deactivate';
import { Injectable } from '@angular/core';
import { Router, CanActivate ,CanDeactivate} from '@angular/router';

export class ConfirmDeactivateGuard implements CanDeactivate<CanDeactivateComponent> {

  canDeactivate(target: CanDeactivateComponent) {
    if(target.hasChanges()){
        return window.confirm('Do you really want to cancel?');
    }
    return true;
  }
}