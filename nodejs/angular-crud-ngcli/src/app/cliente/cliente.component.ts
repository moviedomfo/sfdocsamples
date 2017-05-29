import { Component, OnInit } from '@angular/core';
import {ClienteService} from './service/cliente.service';
/*import {Dropdown} from './dropdown.directive';
import {DropdownMenu} from './dropdown-menu.directive';
import {DropdownToggle} from './dropdown-toggle.directive';*/
//  import { ModalDialogComponent } from '../modal-dialog/modal-dialog.component';
//  import { DialogService } from "ng2-bootstrap-modal";


@Component({
  selector: 'app-cliente',
  templateUrl: './cliente.component.html',
  styleUrls: ['./cliente.component.css'],
  
})
export class ClienteComponent implements OnInit {

  private selectedPais:String ='';
  public paises: Array<String> = ["Afghanistan",
    "Albania", "Algeria", "Andorra", "Angola", "Antigua and Barbuda", "Argentina", "Armenia", "Australia", "Austria", "Azerbaijan", "Bahamas", "Bahrain",
    "Bangladesh", "Cote d'Ivoire", "Croatia", "Cuba"];


  //constructor(private dialogService:DialogService) { }
  constructor(private clienteService:ClienteService) {
    //let paises: Array<number> = [1, 2, 3];

  }
  ngOnInit() {
  }

  createClient(event) {
    var str: String = 'Pais seleccionado ' + this.selectedPais;
  alert (str);
   var paicesFiltrados =  this.paises.filter(p=>p.startsWith('Ar') );
    
    
    paicesFiltrados.forEach(element => {
        alert(element);
    });
    //alert(str);

  }
onPaisSelection2(pais){

   this.selectedPais = pais;
  }

onPaisSelection(event){

   alert(this.selectedPais);
  

  }
  // showConfirm() {
  //             let disposable = this.dialogService.addDialog(ModalDialogComponent, {
  //                 title:'Confirm title', 
  //                 message:'Confirm message'})
  //                 .subscribe((isConfirmed)=>{
  //                     //We get dialog result
  //                     if(isConfirmed) {
  //                         alert('accepted');
  //                     }
  //                     else {
  //                         alert('declined');
  //                     }
  //                 });
  //             //We can close dialog calling disposable.unsubscribe();
  //             //If dialog was not closed manually close it by timeout
  //             setTimeout(()=>{
  //                 disposable.unsubscribe();
  //             },10000);
  //         }
}
