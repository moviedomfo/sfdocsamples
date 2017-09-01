export interface IContextInformation  {
     Culture?: string;
     ProviderNameWithCultureInfo?: string;
     HostName?:string;
     HostIp?:string;
     HostTime: Date;
     ServerName: string;
     ServerTime?: Date;
     UserName?: string;
     UserId?: string;
     AppId: string;
     ProviderName: string;
}
export class ContextInformation implements IContextInformation  {
    Culture?: string;
    ProviderNameWithCultureInfo?: string;
    HostName?:string;
    HostIp?:string;
    HostTime: Date;
    ServerName: string;
    ServerTime?: Date;
    UserName?: string;
    UserId?: string;
    AppId: string;
    ProviderName: string;
}
export interface IRequest{
    
    SecurityProviderName?: string;
    Encrypt?: boolean;
    //Error?:ServiceError;
    ServiceName?: string;
    BusinessData?:object;
    CacheSettings?:object;
    ContextInformation:IContextInformation;
}

export interface IResponse{
    
    SecurityProviderName?: string;
    Encrypt?: boolean;
    Error?:ServiceError;
    ServiceName?: string;
    BusinessData?:object;
    CacheSettings?:object;
    ContextInformation:IContextInformation;
}
export class Result implements IResponse {
    
    SecurityProviderName?: string;
    Encrypt?: boolean;
    Error?:ServiceError;
    ServiceName?: string;
    BusinessData?:object;
    CacheSettings?:object;
    ContextInformation:ContextInformation;
}
export class Request implements IRequest{
  
    SecurityProviderName?: string;
    Encrypt?: boolean;
    Error?:object;
    ServiceName?: string;
    BusinessData?:object;
    CacheSettings?:object;
    ContextInformation:ContextInformation;
}
export interface IParam
{
      Id: number;
    Name:string;
    ParentId?:number
}
export class Param implements IParam{
    Id: number;
    Name:string;
    ParentId?:number
}

  /// Contiene informacion del error de un servicio.-
export class ServiceError{

   //    Gets a string representation of the frames on the call stack at the time
   //   the current exception was thrown.
   Message:string;
   StackTrace:string;
   Type:string;
   Machine:string;

}