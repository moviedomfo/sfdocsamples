
import { Http, Response, RequestOptions, Headers } from '@angular/http';
import { Param, IParam, IContextInformation ,IRequest} from '../model/common.model';
let headers = new Headers({ 'Content-Type': 'application/json' });
     headers.append('Access-Control-Allow-Methods', 'GET, POST, PATCH, PUT, DELETE, OPTIONS');
     headers.append('Access-Control-Allow-Headers', 'Content-Type, Access-Control-Allow-Headers, Authorization, X-Requested-With');
     headers.append('Access-Control-Allow-Origin', 'http://localhost:4200');

let options = new RequestOptions({ headers: headers });
export  const HealtConstants={
     CNN_STRING_HEALTH: {
            user: 'sa',
            password: 'as',
            server: 'SANTANA\\SQLEXPRESS2008',
            database: 'health3',

            options: {
                encrypt: true // Use this if you're on Windows Azure 
                }
            },
     HealthAPI_URL:"http://localhost:63251/api/",
     HealthExecuteAPI_URL:"http://localhost:63251/api/patients/execute",
     httpOptions:options
}
  export  const contextInfo ={
        Culture: "ES-AR",
        ProviderNameWithCultureInfo:"",
        HostName : 'localhost',
        HostIp : '10.10.200.168',
        HostTime : new Date(),
        ServerName : 'WebAPIDispatcherClienteWeb',
        ServerTime : new Date(),
        UserName : 'moviedo',
        UserId : '',
        AppId : 'Healt',
        ProviderName: 'health'
      };


      export  const patientList = [
      {
        PatientId: 100,
        IdPersona: 1,
        Apellido: "Oviedo",
        Nombre: "Marcelo",
        FechaAlta: new Date(),
        LastAccessTime: new Date(),
        LastAccessUserId: "",
        LastHealthInstId: '',

      },
      {
        PatientId: 110,
        IdPersona: 22,
        Apellido: "Hendryxo",
        Nombre: "Jimmy",
        FechaAlta: new Date(),
        LastAccessTime: new Date(),
        LastAccessUserId: "",
        LastHealthInstId: ''
      }

    ];
export  const TipoParametroEnum = 
      {
        Especialidad : 500,
        Profecion : 100,
        EstadoCivil : 600,
        TipoDocumento : 601,
        TipoRecepcion : 200,
        TipoEventoMedico : 700,//antes tipo consulta
        TipoMedioContacto : 1000,
        Paises : 1050,
        Localidad : 1200,
        Provincia : 1100,
        AllergiesTypes : 10100,
        AllergiesItemTypes : 101012
      };

      
export const CommonValuesEnum =
    {
        TodosComboBoxValue : -1000,
        VariosComboBoxValue : -2000,
        SeleccioneUnaOpcion : -3000,
        Ninguno : -4000,
        /// <summary>
        /// Esta opcion es usada para seleccion de Mutuales .- Caso Sin mutual particular
        /// </summary>
        Particular : -5000
    };
    export const DayNamesIndex_ES =
    {
        //SAB	VIE	JUE	MIE	MAR	LUN	DOM
        Sabado : 0,
        Viernes : 1,
        Jueves : 2,
        Miercoles : 3,
        Martes : 4,
        Lunes : 5,
        Domingo : 6
    }

// expect commonHelper = function function_name(argument) {
// createFwk_SOA_REQ(bussinesData:any):IRequest
//   {
//     let contextInfo: IContextInformation;
//     let req :IRequest;
//     contextInfo.Culture = "ES-AR";
//     contextInfo.ProviderNameWithCultureInfo = "";
//     contextInfo.HostName  =  'localhost';
//     contextInfo.HostIp  =  '10.10.200.168';
//     contextInfo.HostTime  =  new Date(),
//     contextInfo.ServerName  =  'WebAPIDispatcherClienteWeb';
//     contextInfo.ServerTime  =  new Date();
//     contextInfo.UserName  =  'moviedo',
//     contextInfo.UserId  =  '';
//     contextInfo.AppId  =  'Healt';
//     contextInfo.ProviderName = 'health';
//     req.ContextInformation=contextInfo;
//     req.BusinessData=bussinesData;
//     req.Error =null;
//     req.SecurityProviderName="";
//     req.Encrypt=false;

//     return req;
//   }
  
// }
//module.exports =  HealtConstants;
//module.exports =  contextInfo;
// const  CNN_STRING_HEALTH  = {
//     user: 'sa',
//     password: 'as',
//     server: 'SANTANA\\SQLEXPRESS2008',
//     database: 'health3',

//     options: {
//         encrypt: true // Use this if you're on Windows Azure 
//     }
// }