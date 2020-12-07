

export interface IContextInformation {
    Culture?: string;
    ProviderNameWithCultureInfo?: string;
    HostName?: string;
    HostIp?: string;
    HostTime: Date;
    ServerName: string;
    ServerTime?: Date;
    UserName?: string;
    userId?: string;
    AppId: string;
    ProviderName: string;
}
export class ContextInformation implements IContextInformation {
    Culture?: string;
    ProviderNameWithCultureInfo?: string;
    HostName?: string;
    HostIp?: string;
    HostTime: Date;
    ServerName: string;
    ServerTime?: Date;
    UserName?: string;
    UserId?: string;
    AppId: string;
    ProviderName: string;
}


export interface IRequest {

    SecurityProviderName?: string;
    Encrypt?: boolean;
    //Error?:ServiceError;
    ServiceName?: string;
    BusinessData?: object;
    CacheSettings?: object;
    ContextInformation: IContextInformation;
}

export class IpInfo {
    public ip: string;
    public loc: string;//"37.385999999999996,-122.0838",
    public city: string;//"Mountain View"
    public region: string;//"California"
    public country: string;//"US
}

export class ExecuteReq {
    serviceProviderName?: string;
    serviceName?: string;
    jsonRequest?: string;
}
export interface IResponse {

    SecurityProviderName?: string;
    Encrypt?: boolean;
    Error?: ServiceError;
    ServiceName?: string;
    BusinessData?: object;
    CacheSettings?: object;
    ContextInformation: IContextInformation;
}
export class Result implements IResponse {

    SecurityProviderName?: string;
    Encrypt?: boolean;
    Error?: ServiceError;
    ServiceName?: string;
    BusinessData?: object;
    CacheSettings?: object;
    ContextInformation: ContextInformation;
}

export class IAPIRequest  {
    SecurityProviderName?: string;
    UserId?: string;
    ClientIp?:string;
    Culture:string;
    AppId:string;
}

export class Request implements IRequest {

    SecurityProviderName?: string;
    Encrypt?: boolean;
    Error?: object;
    ServiceName?: string;
    BusinessData?: object;
    CacheSettings?: object;
    ContextInformation: ContextInformation;
}

export class ParamBE {

    ParamId: number;
    ParentId?: number;
    Culture: string;
    Name: string;
    Description: string;
}


export class UbicacionItemBE {  

    id: number;
    nombre: string;
   
}

export class localidadesResponse {
    public cantidad: number;
    public  inicio: number;

    public localidades :UbicacionItemBE[];
   
}

/// Contiene informacion del error de un servicio.-
// if(e instanceof EvalError)
export class ServiceError extends Error {


    Message: string;
    StackTrace: string;
    Type: string;
    Machine: string;
    Status: number;

}


export class FwkEvent {
    Message: string;
    Source: string;
    Machine: string;
    LogDate: Date;
    Type: string;
    User: string;
}


export class HealthInstitutionBE {

    public HealthInstitutionId: string;
    public HealthInstitutionType?: number;
    public Street: string;
    public StreetNumber?: number;
    public Floor: string;
    public CountryId?: number;
    public ProvinceId?: number;
    public CityId?: number;
    public RazonSocial: string;
    public Province: string;
    public City: string;
    public Neighborhood: string;
    public ZipCode: string;
    public CreatedDate: Date;
    public LastAccessTime?: Date;
    public LastAccessUserId?: string;
    public ActivationKey: string;
    public Description: string;
    public CUIT: string;
    public HealthInstitutionIdParent?: string;
}

export class UserTask {
    constructor (options?: {taskId:number; tittle: string; completedPercent: number;descripción:string;createdDate:Date,priority:string}) {
        if (options) {
            this.taskId = options.taskId;
            this.tittle = options.tittle;
            this.descripción = options.descripción;
            this.completedPercent = options.completedPercent;
            this.createdDate = options.createdDate;
            this.priority = options.priority;
            
            
        }
    }
    taskId:number;
    tittle: string;
    descripción: string;
    completedPercent: number;
    createdDate: Date;
    priority: string;
}

export class UserMessage {
    constructor (options?: {messageId:number; tittle: string; completedPercent: number;body:string;createdDate:Date}) {
        if (options) {
            this.messageId = options.messageId;
            this.tittle = options.tittle;
            this.body = options.body;
            this.completedPercent = options.completedPercent;
            this.createdDate = options.createdDate;
            
            
   
        }
    }
    messageId:number;
    tittle: string;
    body: string;
    completedPercent: number;
    createdDate: Date;
    timeAgo: string;
}

export class HelperBE {
    public getFullName(name: string, lastName: string) {
        return lastName + ', ' + name;
    }
}



export class ApiServerInfo {
    public HostName: string;
    public SQLServerMeucci: string;
    public SQLServerSeguridad: string;
    public Ip: string;
    public email: string;
}