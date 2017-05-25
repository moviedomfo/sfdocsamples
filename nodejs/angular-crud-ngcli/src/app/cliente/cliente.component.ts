import { Component, OnInit } from '@angular/core';
 import { ModelDialogComponent } from '../model-dialog/model-dialog.component';
    import { DialogService } from "ng2-bootstrap-modal";
@Component({
  selector: 'app-cliente',
  templateUrl: './cliente.component.html',
  styleUrls: ['./cliente.component.css']
})
export class ClienteComponent implements OnInit {

  constructor(private dialogService:DialogService) { }

  ngOnInit() {
  }

  createClient(event){
    alert('Crear cliente');
  }
showConfirm() {
            let disposable = this.dialogService.addDialog(ModelDialogComponent, {
                title:'Confirm title', 
                message:'Confirm message'})
                .subscribe((isConfirmed)=>{
                    //We get dialog result
                    if(isConfirmed) {
                        alert('accepted');
                    }
                    else {
                        alert('declined');
                    }
                });
            //We can close dialog calling disposable.unsubscribe();
            //If dialog was not closed manually close it by timeout
            setTimeout(()=>{
                disposable.unsubscribe();
            },10000);
        }
}
