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