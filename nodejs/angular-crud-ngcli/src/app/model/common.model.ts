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
    Error?:object;
    ServiceName?: string;
    BusinessData?:object;
    CacheSettings?:object;
    ContextInformation:IContextInformation;
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